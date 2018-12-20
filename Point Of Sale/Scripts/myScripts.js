//var Categories = []

////fetch category for database
//function LoadCategory(element) {
//    if (Categories.length == 0) {
//        //ajax function for fetch data
//        $.ajax({
//            type: "GET",
//            url: '/Purchase/getProductCategories',
//            success: function (data) {
//                Categories = data;

//                //render category
//                renderCategory(element);
//            }
//        })
//    }
//    else {
//        //render category for the element
//        renderCategory(element);
//    }
//}

////this code for render category
//function renderCategory(element) {
//    var $ele = $(element);
//    $ele.empty();
//    $ele.append($('<option/>').val('0').text('Select'));
//    $.each(Categories, function (i, val) {
//        $ele.append($('<option/>').val(val.categoryId).text(val.CategoryName));       
//    })
//}

////fetch product for database
//function LoadProduct(categoryDD) {
//    //ajax function for fetch data
//    $.ajax({
//        type: "GET",
//        url: "/Purchase/getProducts",
//        data: { 'categoryId': $(categoryDD).val() },
//        success: function (data) {
//            //render product to appropiate dropdown
//            renderProduct($(categoryDD).parent('.mycontainer').find('select.product'), data);
//        },
//        error: function (error) {
//            console.log(error);
//        }
//    })
//}

////this code for render product
//function renderProduct(element, data) {
//    //render product
//    var $ele = $(element);
//    $ele.empty();
//    $ele.append($('<option/>').val('0').text('Select'));
//    $.each(data, function (i, val) {
//        $ele.append($('<option/>').val(val.ProductId).text(val.ProductName));
//    })
//}

////click event
//$(document).ready(function () {
//    $('#productCategory').change(function () {
//        var productCategoryId = $('#productCategory').val();
//        alert(productCategoryId);

//        $.get("Purchase/getProducts", { productCategoryId: productCategoryId }, function (data, status) {
//            $('#product').empty();
//            $.each(data, function (index, row) {
//                $('#product').append("<option value='" + row.ProductId + "'>" + row.ProductName + "</option>");
//            });
//        });
//    });

//    //add button click event
//    $('#add').click(function () {
//        //valiadtion and add to order item
//        var isAllValid = true;

//        if ($('#productCategory').val() == "0") {
//            isAllValid = false;
//            $('#productCategory').siblings('span.error').css('visibility', 'visible');
//        }
//        else {
//            $('#productCategory').siblings('span.error').css('visibility', 'hidden');
//        }

//        if ($('#product').val() == "0") {
//            isAllValid = false;
//            $('#product').siblings('span.error').css('visibility', 'visible');
//        }
//        else {
//            $('#product').siblings('span.error').css('visibility', 'hidden');
//        }

//        if (!($('#quantity').val().trim() != '' && (parseInt($('#quantity').val()) || 0))) {
//            isAllValid = false;
//            $('#quantity').siblings('span.error').css('visibility', 'visible');
//        }
//        else {
//            $('#quantity').siblings('span.error').css('visibility', 'hidden');
//        }

//        if (!($('#rate').val().trim() != '' && !isNaN($('#rate').val().trim()))) {
//            isAllValid = false;
//            $('#rate').siblings('span.error').css('visibility', 'visible');
//        }
//        else {
//            $('#rate').siblings('span.error').css('visibility', 'hidden');
//        }

//        if (isAllValid) {
//            var $newRow = $('#mainrow').clone().removeAttr('id');
//            $('.pc', $newRow).val($('#productCategory').val());
//            $('.product', $newRow).val($('#product').val());

//            //replace add button for remove button
//            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

//            //remove id attribute for new clone row
//            $('#productCategory,#product,#quantity,#rate,#add', $newRow).removeAttr('id');
//            $('span.error', $newRow).remove();

//            //append clone row
//            $('#orderdetailsItems').append($newRow);

//            //clear select data 
//            $('#productCategory,#product').val('0');
//            $('#quantity,#rate').val('');
//            $('#orderItemError').empty();
//        }

//    })

//    //remove button click event
//    $('#orderdetailsItems').on('click', '.remove', function () {
//        $(this).parents('tr').remove();
//    });

//    //save order to our database
//    $('#submit').click(function () {
//        //validation check and save database order item
//        var isAllValid = true;
//        $('#orderItemError').text('');
//        var list = [];
//        var errorItemCount = 0;

//        $('#orderdetailsItems tbody tr').each(function (index, ele) {
//            if ($('select.product', this).val() == "0" ||
//                (parseInt($('.quantity', this).val()) || 0) == 0 ||
//                $('.rate', this).val() == "" ||
//                isNaN($('.rate', this).val())
//            ) {
//                errorItemCount++;
//                $(this).addClass('error');
//            } else {
//                var orderItem = {
//                    ProductId: $('select.product', this).val(),
//                    Quantity: parseInt($('.quantity', this).val()),
//                    Rate: parseFloat($('.rate', this).val())
//                }
//                list.push(orderItem);
//            }
//        })

//        //check error or not order item details
//        if (errorItemCount > 0) {
//            $('#orderItemError').text(errorItemCount + "Invalid entry in order item list.");
//            isAllValid = false;
//        }

//        //error message any valid entry
//        if (list.length == 0) {
//            $('#orderItemError').text('At least 1 order item required');
//            isAllValid = false;
//        }

//        //orderNo validation
//        if ($('#orderNo').val().trim() == '') {
//            $('#orderNo').siblings('span.error').css('visibility', 'visible');
//            isAllValid = false;
//        }
//        else {
//            $('#orderNo').siblings('span.error').css('visibility', 'hidden');
//        }

//        //orderDate validation
//        if ($('#orderDate').val().trim() == '') {
//            $('#orderDate').siblings('span.error').css('visibility', 'visible');
//            isAllValid = false;
//        }
//        else {
//            $('#orderDate').siblings('span.error').css('visibility', 'hidden');
//        }

//        //order details record save database
//        if (isAllValid) {
//            var data = {
//                OrderNo: $('#orderNo').val().trim(),
//                OrderDateString: $('#orderDate').val().trim(),
//                Description: $('#description').val().trim(),
//                OrderDetails: list
//            }
//            $(this).val('Please wait....');

//            //ajax method for post order object to MVC action for save database
//            $.ajax({
//                type: 'POST',
//                url: 'Purchase/save',
//                data: JSON.stringify(data),
//                contentType: 'application/json',
//                success: function (data) {
//                    if (data.success) {
//                        alert('Successfully saved.');

//                        //clear all form
//                        list = [];
//                        $('#orderNo,#orderDate,#description').val('');
//                        $('#orderdetailsItems').empty();
//                    }
//                    else {
//                        alert('Error');
//                    }
//                    $('#submit').text('Save');
//                },
//                error: function (error) {
//                    console.log(error);
//                    $('#submit').text('Save');
//                }
//            });
//        }

//    });
//});

////load category when page loded first time
////LoadCategory($('#productCategory'));