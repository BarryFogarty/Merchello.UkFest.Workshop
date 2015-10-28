$(function () {
    Store.init();
});

var Store = {

    init : function() {
        Store.Controls.init();
        Store.Checkout.init();
    },

    Controls : {
        
        init: function () {
            // category sort by
            var sortBy = $('#sort-by');
            if (sortBy.length > 0) {
                $(sortBy).change(function() {
                    Store.Category.changeSortOrder($(sortBy).val());
                });
            }

            var modals = $('[data-productmodal]');
            if (modals.length > 0) {
                $.each(modals, function(idx, link) {
                    $(link).click(function () {
                        Store.Modal.getModal(this);
                    });
                });
            }
        }
    },

    Category : {
        changeSortOrder : function(field) {
            $.get(Store.Category.surfaceEndPoint + 'setsortfield', { sort: field }, function (data) {
                // TODO we could return the Collection.cshtml partial view here and swap it out 
                // rather than reloading the page
                if (data == 'success') {
                    location.reload();
                }
            });
        },
        surfaceEndPoint: '/umbraco/surface/category/'
    },

    Modal: {
        getModal : function(link) {
            var key = $(link).data('productmodal');
            $.get(Store.Modal.apiEndPoint + 'modal', { key: key }, function (data) {
                $('#modal-name').text(data.name);
                $('#modal-desc').text(data.description || '');
                console.info(data);
                if (data.onSale) {
                    $('#modal-onsale').show();
                } else {
                    $('#modal-onsale').hide();
                }

                if (data.isNew) {
                    $('#modal-isnew').show();
                } else {
                    $('#modal-isnew').hide();
                }
                $('#ProductKey').val(data.key);
                Store.Modal.assignChoices(data.possibleChoices),
                Store.Modal.assignThumbs(data.images);
                Store.Modal.setPrice(data);
                $('#modal-result').show();
            });
        },
        assignChoices : function(choices) {
            if (choices.length > 0) {
                var div = document.createElement('div');
                $(div).addClass('sizes');
                var h3 = document.createElement('h3');
                $(h3).text('Available Sizes');
                $(div).append(h3);
                for (var i = 0; i < choices.length; i++) {
                    $(div).append(Store.Modal.createChoiceRadio(choices[i], i === 0));
                }
                $('#choice-wrapper').append(div);
            }
        },
        createChoiceRadio : function(choice, isFirst) {
            var key = choice.item1;
            var name = choice.item2;

            var label = document.createElement('label');
            $(label).attr('for', key);

            var a = document.createElement('a');
            $(a).attr('href', '#').text(name);
            if (isFirst) {
                $(a).addClass('active');
            }

            $(a).click(function(e) {
                    e.preventDefault();
                    $('.sizes a').removeClass('active');
                    $('.size-input').prop('checked', false);
                    $(this).addClass('active');
                $(this).next('input').prop('checked', true);
            });

            $(label).append(a);

            var input = document.createElement('input');
            $(input).attr('type', 'radio').attr('name', 'OptionChoice').attr('value', key).addClass('size-input');
            if (isFirst) {
                $(input).attr('checked', 'checked');
            }
            $(label).append(input);

            return label;

            //var elem = '<label for="{key}">' +
            //    '<a href="#" class="active">30"</a>' +
            //    '<input checked="checked" class="size-input" id="OptionChoice" name="OptionChoice" type="radio" value="3a37fe72-29ad-465c-85a3-60bc22cf63c2">' +
            //    '</label>';


        },
        assignThumbs : function(images) {
            if (images.length > 0) {
              var count = images.length < 3 ? images.length : 3;
              for (var i = 0; i < 3; i++) {
                  if (i == 0) {
                      $('#modal-image').attr('src', images[i]);
                  }

                  if (i < count) {
                      $('#modal-athumb' + i).attr('href', images[i]);
                      $('#modal-athumb' + i).attr('src', images[i]);
                      $('#modal-thumb' + i).attr('src', images[i]);
                      $('#modal-thumb' + i).show();
                      $('#modal-athumb' + i).show();
                  } else {
                      $('#modal-athumb' + i).hide();
                      $('#modal-thumb' + i).hide();
                  }
                      
              }
          }  
        },
        setPrice : function(p) {
            var price = '<del>{0}</del> {1}';
            if (p.onSale) {
                price = price.replace('{0}', p.price).replace('{1}', p.salePrice);
            } else {
                price = p.price;
            }
            $('[data-modal="price"]').html(price);
        },
        apiEndPoint: '/umbraco/api/modalapi/'
    },

    Checkout : {
        init : function() {
            $("#checkout-forms").steps({

                /* Behaviour */
                headerTag: "h3",
                bodyTag: "form",
                enableFinishButton: false,
                enablePagination: false,
                enableAllSteps: true,
                titleTemplate: "#title#",

                /* Labels */
                labels: {
                    //cancel: "Cancel",
                    current: "",
                    //pagination: "Pagination",
                    //finish: "Finish",
                    //next: "Next",
                    //previous: "Previous",
                    //loading: "Loading ..."
                },

                /* Events */
                onInit: function (event, currentIndex) {
                    $("#checkout-forms ul").addClass("nav nav-pills nav-justified");
                    var stage = $('#View_Stage').val();
                    Store.Checkout.setMaxStage(stage * 1);
                }
            });
        },
        setMaxStage : function(current) {
            for (var i = current + 1; i <= 3; i++) {
                $('#checkout-forms-t-' + i).unbind();
                $('#checkout-forms-t-' + i).click(function(e) {
                    e.preventDefault();
                });
            }
            $('#checkout-forms-t-' + current).trigger('click');
        }
    }
};