  $(document).ready(function () {

            $("div#coffee-order div").hide();
            $("div#coffee-order div:first").show();
            $(":button").click(function () {
                var parentDiv = $(this).parent();
                $("div#coffee-order div").hide();
                if ($(this).val() == "Previous") {
                    var prevDiv = parentDiv.prev();
                    prevDiv.show();
                }
                if ($(this).val() == "Next") {
                    var nextDiv = parentDiv.next();
                    nextDiv.show();
                }
            });


            $("div#divBasic").on("click", ".coffee-options", function (e) {
                $this = $(this);
                var url = "@Url.Action("ShowCoffeeType", "Visualizations")"
                var coffeetype = $this.val();
                requester.ajaxGet(url, { coffeetype })
                .then(data => $('#coffee').html(data));

            });

            $("div#divAddress").on("click", ".size-options", function (e) {
                $this = $(this);
                var url = "@Url.Action("ShowCoffeeSize", "Visualizations")"
                var coffeesize = $this.val()
                var coffeetype = $('input[class=coffee-options]:checked').val();
                requester.ajaxGet(url, { coffeesize, coffeetype })
                .then(data => $('#coffee').html(data));

            });

            $("div#divContact").on("click", ".condiment-options", function () {
                $this = $(this);
                var url = "@Url.Action("ShowCondiment", "Visualizations")"
                var condiment = $this.attr('data-condiment');
                requester.ajaxGet(url, { condiment, condiment })
                .then(data => $('#condiments').append(data));
            });
        });