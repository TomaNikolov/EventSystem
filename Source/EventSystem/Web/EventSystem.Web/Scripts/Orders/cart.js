(function () {
    var $ticketPurchase = $('#ticket-purchase');
    $ticketPurchase.on('click', 'button', function () {
        var $this = $(this);
        var id = $this.attr('data-id');
        $.post('/order/RemoveFromShoppingCart', { id: id }, function (data) {
            var badgeContainer = $('[data-id=\"shopping-cart\"]')
            $('span[data-id=\"shopping-cart-badge\"]').remove()

            var badge = $('<span />')
                .attr('class', 'badge badge-red')
                .attr('data-id', 'shopping-cart-badge')
                .text(data.ItemsCount)

            $('span[data-id=\"total\"]').text(data.TotalPrice)
            badgeContainer.append(badge);
            $this.parent().parent().remove();
        })
    })
}());