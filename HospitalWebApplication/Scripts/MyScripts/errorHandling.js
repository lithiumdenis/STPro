function processError(ex, selector) {
    var errorHtml = "Server didn't respond in expected manner.";
    if (ex.status) {
        if (ex.responseJSON) {
            templateLoader.get('errorMessage', function (template) {
                $.tmpl(template, ex.responseJSON).appendTo(selector);
                $(selector).show();
                hideAfter(selector, 3);
            });
            return;
        }
        else {
            errorHtml = ex.statusText;
        }
    }
    $(selector).html(errorHtml);
    $(selector).show();
    hideAfter(selector, 3);
}