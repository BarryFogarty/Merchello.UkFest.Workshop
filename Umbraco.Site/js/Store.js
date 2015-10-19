$(function () {
    Store.init();
});

var Store = {

    init : function() {
        Store.Controls.init();
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
                        console.info('got here');
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
                $('#modal-desc').text(data.description);
                
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
                Store.Modal.assignThumbs(data.images);
                Store.Modal.setPrice(data);
                $('#modal-result').show();
            });
        },
        assignThumbs : function(images) {
            if (images.length > 0) {
              var count = images.length < 3 ? images.length : 3;
              for (var i = 0; i < 3; i++) {
                  if (i == 0) {
                      $('#modal-image').attr('src', images[i]);
                  }

                  if (i < count) {
                      var idx = i + 1;
                      $('#modal-athumb' + i).attr('href', images[i]);
                      $('#modal-athumb' + i).attr('src', images[i]);
                      $('#modal-thumb' + i).attr('src', images[i]);
                      console.info($('#modal-athumb' + i));
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
    }
};