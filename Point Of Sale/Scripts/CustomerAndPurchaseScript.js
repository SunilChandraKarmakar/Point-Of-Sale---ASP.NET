//add button click function
$(function () {
    $("#add").click(function () {
        var isValid = true;

        //validation for Product Item
        if (document.getElementById("productsItems").selectedIndex == 0) {
            $('#productsItems').siblings('span.error').text('Please select Item');
            isValid = false;
        }
        else {
            $('#productsItems').siblings('span.error').text('');
        }

        //validation for Quantity
        if (!($("#quantity").val().trim() != '' && (parseInt($('#quantity').val()) || 0))) {
            $('#quantity').siblings('span.error').text('Please enter Quantity');
            isValid = false;
        }
        else {
            $('#quantity').siblings('span.error').text('');
        }

        //validation for price
        if (!($("#price").val().trim() != '' && (parseFloat($('#price').val()) || 0))) {
            $('#price').siblings('span.error').text('Please enter Price');
            isValid = false;
        }
        else {
            $('#price').siblings('span.error').text('');
        }

        //validation is complete
        if (isValid) {

            //total equation
            var total = parseInt($("#quantity").val()) * parseFloat($("#price").val());
            $("#total").val(total);

            var ProductID = document.getElementById("productsItems").value;
            var $newRow = $("#MainRow").clone().removeAttr('id');
            $('.productsItems', $newRow).val(ProductID);
            $('#add', $newRow).addClass('remove').html('Remove').removeClass('btn-success').addClass('btn-danger');
            $('#productsItems, #quantity, #price', $newRow).attr('disabled', true);
            $("#productsItems, #quantity, #price, #total", $newRow).removeAttr("id");
            $("Span.error", $newRow).remove();
            $("#OrderItems").append($newRow[0]);

            //clear item
            document.getElementById("productsItems").selectedIndex = 0;
            $('#price').val('');
            $('#quantity').val('');
            $('#total').val('');
        }
    });

    //remove button code
    $("#OrderItems").on("click", ".remove", function () {
        $(this).parents("tr").remove();
    });

    //save database order item
    $("#submit").click(function () {
        var isValid = true;
        var itemsList = [];

        $("#OrderItems tr").each(function () {
            var item = {
                ProductID: $('select.productsItems', this).val(),
                Price: $('.price', this).val(),
                Quantity: $('.quantity', this).val(),
                TotalPrice: $('.total', this).val()
            }
            itemsList.push(item);
        });

        //check validation
        if (itemsList.length == 0) {
            $('#orderMessage').text('Please add items !');
            isValid = false;
        }

        var descriptionShow = $("#description").val();

        if (isValid) {
            var data = {
                CustomerName: $("#customer_name").val(),
                OrderNumber: $("#order_number").val(),
                Date: $("#date").val(),
                description: descriptionShow,
                Items: itemsList
            }

            $("#submit").attr("disabled", true);
            $("#submit").html('Please wait ...');

            //Add Order button code
            $.ajax({
                type: 'POST',
                url: '/CustomerAndPurchase/AddCustomerPurchase',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        $('#orderMessage').text(data.message);
                        $("#submit").attr("disabled", false);
                        $("#submit").html('Submited');
                        location.reload();
                        window.open("../Report.aspx", "_blank");
                    }
                    else {
                        $('#orderMessage').text(data.message);
                        $("#submit").attr("disabled", false);
                        $("#submit").html('Submited');
                    }
                }
            });
        }
    });
});