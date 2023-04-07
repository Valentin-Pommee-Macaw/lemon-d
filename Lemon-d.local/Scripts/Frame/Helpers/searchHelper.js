(function (window, document, lemon_d, $) {
    lemon_d.searchHelper = lemon_d.searchHelper || {};

    lemon_d.searchHelper.toggleSearchOverlay = function () {
        $('.search-popup').toggleClass('v-none');
        $('.search-popup').toggleClass('active');
        $('.button-addGame').toggleClass('active');
        if ($('.button-addGame').hasClass('active')) {
            $(window).keydown(function (e) {
                if (e.key == "Escape") {
                    lemon_d.searchHelper.toggleSearchOverlay();
                }
            });
        }
    };

} (window, document, window.lemon_d = window.lemon_d || {}, $));