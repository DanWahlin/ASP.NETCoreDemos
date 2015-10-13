(function () {

    var div = $('#customers');
    $.getJSON('/api/dataservice/customers', function (custs) {
        var html = '<ul>'
        custs.forEach(function (customer) {
            html += '<li>' + customer.firstName + ' ' + customer.lastName + '</li>';
        });
        html += '</ul>';
        div.html(html);
    });

}())