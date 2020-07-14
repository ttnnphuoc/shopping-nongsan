$(document).ready(function () {
    var productDataList = [];
    // Action plus, Minus quantity product
    $(".quantity-right-plus,.quantity-left-minus").click(function (event) {
        var numberQuantity = parseInt( $("#quantity").val());
        var type = event.currentTarget.dataset.type;
        numberQuantity = type === "plus" ? numberQuantity + 1 : numberQuantity - 1;
        if (type === "minus" && numberQuantity === 0) {
            numberQuantity = 1;
        }
        $("#quantity").val(numberQuantity);
    });

    // Action add to cart
    $(".btn-add-to-cart").click(function (event) {
        var id = event.currentTarget.dataset.id;
        productDataList.push(id);
        $("#cart-info").html("<span class='icon-shopping_cart'></span>["+productDataList.length+"]");
    });
});

