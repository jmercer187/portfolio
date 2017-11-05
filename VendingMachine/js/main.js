
$(document).ready(function () {

    loadVendItems();

    $('#add-dollar-button').click(function (event) {

        var a = $('#money-in-system').val();
        var aParse = parseFloat(a);
        var b = aParse + 1.00;
        var bFixed = b.toFixed(2)

        $('#money-input-display').val(bFixed);
        $('#money-in-system').val(bFixed);
    });

    $('#add-quarter-button').click(function (event) {

        var a = $('#money-in-system').val();
        var aParse = parseFloat(a);
        var b = aParse + .25;
        var bFixed = b.toFixed(2)

        $('#money-input-display').val(bFixed);
        $('#money-in-system').val(bFixed);
    });

    $('#add-dime-button').click(function (event) {

        var a = $('#money-in-system').val();
        var aParse = parseFloat(a);
        var b = aParse + .1;
        var bFixed = b.toFixed(2)

        $('#money-input-display').val(bFixed);
        $('#money-in-system').val(bFixed);
    });

    $('#add-nickel-button').click(function (event) {

        var a = $('#money-in-system').val();
        var aParse = parseFloat(a);
        var b = aParse + .05;
        var bFixed = b.toFixed(2)

        $('#money-input-display').val(bFixed);
        $('#money-in-system').val(bFixed);
    });

    $('#cancel-vend-button').click(function (event) {

        clearCurrency();
        $('#change-return-display').val(0);
        $('#message-display').val('Please Select an Item!');
    });

    $('#make-purchase-button').click(function (event) {

        var itemId = $('#item-selected-display').val();

        selectItem(itemId);

    });

})


function loadVendItems() {
    clearVendItems();
    var vendingContent = $('#vendingContent');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function (data, status) {
            $.each(data, function (index, item) {
                var id = item.id;
                var name = item.name;
                var quantity = item.quantity;
                var price = item.price;

                var priceFixed = price.toFixed(2)

                var row = '<p>Item ID: ' + id + '</p>';
                row += '<p class="text-center"><strong>' + name + '</strong></p>';
                row += '<p class="text-center">Cost: $' + priceFixed + '</p>';
                row += '<p class="text-center">Quantity in Stock: ' + quantity + '</p>';
                row += '<p class="text-center"><a type="button" class="btn btn-info col-sm-12" onclick="selectItem(' + id + ')">SELECT / PURCHASE</a></p>';

                var htmlBlock = '<div class="panel panel-default col-sm-4"><div class="panel-body">' + row + '</div></div>'

                vendingContent.append(htmlBlock);
                clearCurrency();
            });
        },
        error: function () {
            $('#connectionErrorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('There was an error stocking the items. Perhaps you need to call the jar or activate CORS?'));
        }

    });
}

function clearVendItems() {
    $('#vendingContent').empty();
}

function clearCurrency() {

    $('#item-selected-display').val('');
    $('#money-input-display').val(0.00);
    $('#money-in-system').val(0);


}

function selectItem(id) {

    var itemId = id;
    $('#item-selected-display').val(itemId)

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + $('#money-in-system').val() + '/item/' + id,
        success: function (data, status) {
            var quarters = data.quarters;
            var qParse = parseInt(quarters);
            var dimes = data.dimes;
            var dParse = parseInt(dimes);
            var nickels = data.nickels;
            var nParse = parseInt(nickels);
            var pennies = data.pennies;
            var pParse = parseInt(pennies);

            var changeReturn = ((qParse * 25) + (dParse * 10) + (nParse * 5) + pParse) / 100;

            var changeFixed = changeReturn.toFixed(2)

            $('#message-display').val('Please take your item.');
            $('#change-return-display').val(changeFixed);

            loadVendItems();

        },

        error: function (data, status) {
            var errorMessage = data.responseJSON.message;
            
            $('#message-display').val(errorMessage);
        }
    });

}

