
$(document.ready(function)) {
    $(#Title).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Home/Teams",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Title, value: item.title };
                    }))
                }
            })
        },
        messeages: {
            noResults: "", results; ""
        }
    });
}
