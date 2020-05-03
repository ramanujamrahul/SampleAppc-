console.log("wassup");
var theFrom = $("#theForm");
theFrom.hide();
var button = $("#buyButton");
button.on("click", function () {
    console.log("Buying Item");
});
var productInfo = $(".product-props li");
productInfo.on("click", function () {
    console.log("you clicked on " + $(this).text())
});