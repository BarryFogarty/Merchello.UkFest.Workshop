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
                    $(link).click(function() {
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
            $.get(Store.Modal.surfaceEndPoint + 'modal', { key: key }, function(data) {
                $('#modal-wrapper').html(data);
            });
        },
        surfaceEndPoint: '/umbraco/surface/modal/'
    }
};