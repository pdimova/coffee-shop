var requester = (function () {

    function ajaxGet(url, params) {
        return new Promise((resolve, reject) => {
            $.ajax({
                type: "GET",
                url: url,
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (response) {
                    resolve(response);
                }
            });
        });
    }

    function ajaxPost(url, body, options = {}) {
        return new Promise((resolve, reject) => {
            let headers = options.headers || {};

            $.ajax({
                type: "POST",
                url: url,
                headers: headers,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(body),
                success: function (response) {
                    resolve(response);
                }
            });
        });
    }

    return {
        ajaxGet: ajaxGet,
        ajaxPost: ajaxPost,
    };
} ());