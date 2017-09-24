var requester = (function () {



    function ajaxGet(url, params) {
        return new Promise((resolve, reject) => {
            $.ajax({
                type: "GET",
                url: url,
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: function (data) {
                    resolve(data);
                }
            });
        });

    }

    return {
        ajaxGet: ajaxGet
    };
}());