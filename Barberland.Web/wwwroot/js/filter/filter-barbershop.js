function FilterBarbershopController(model) {
    var thisObject = this;

    this.SearchButton = $("#SearchButton");
    this.SearchText = $("#SearchText");

    this.OrderBy = $("#OrderBy");
    this.Page = "";

    // put every initialize method here.
    this.Initialise = function () {
        thisObject.RenderModel();
        thisObject.InitialiseEvent();
    };

    this.InitialiseEvent = function () {

        thisObject.SearchButton.click(function (e) {
            e.preventDefault();

            thisObject.SearchText = '';
            thisObject.OrderBy = '';

            $('#OrderBy option:selected').each(function (x, y) {
                var valStatus = y.value;
                if (thisObject.OrderBy == '') {
                    thisObject.OrderBy = valStatus;
                } else {
                    thisObject.OrderBy = thisObject.OrderBy + "|" + valStatus;
                }
            });

            thisObject.SearchText = $('#SearchText').val();

            var url = thisObject.redirectUrl +
                "?searchtext=" + thisObject.SearchText.replace("&", "%26") +
                "&orderby=" + thisObject.OrderBy +
                "&page=" + thisObject.Page;

            document.location.href = url;

        });

        $('#SearchText').keypress(function (e) {
            if (e.which == 13) {
                thisObject.SearchButton.click();
            }
        });
        $('#OrderBy').change(function (e) {
            thisObject.SearchButton.click();
        });
    };

    // assign model to control input.
    this.RenderModel = function () {
        // begin search criteria.
        thisObject.RenderFilterSearchText(thisObject.SearchText);
        thisObject.RenderOrderBy(thisObject.OrderBy);
        // end search criteria.
    };

    this.RenderFilterSearchText = function (data) {
        $('#SearchText').val(data);
    };

    this.RenderOrderBy = function (data) {
        if (data != null && data != "") {
            data = data.split("|");
            $('#OrderBy option').each(function (x, y) {
                var valObj = y.value;
                if (data.includes(valObj)) {
                    y.selected = true;
                }
            });
        }
    };
}
