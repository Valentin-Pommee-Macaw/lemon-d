(function (window, document, lemon_d, $) {
    lemon_d.searchHelper = lemon_d.searchHelper || {};

    $(document).ready(function () {
        var rating = $('.rating--value');
        rating.each(function (e) {
            if (rating[e].innerHTML.toString() >= 75) {
                rating[e].style.color = 'green';
            } else if (rating[e].innerHTML.toString() >= 50) {
                rating[e].style.color = 'yellow';
            } else if (rating[e].innerHTML.toString() >= 1) {
                rating[e].style.color = 'red';
            } else {
                rating[e].innerHTML = '-';
            }
        });
    });

    lemon_d.searchHelper.toggleSearchOverlay = function () {
        $('.search-popup').toggleClass('v-none');
        $('.search-popup').toggleClass('active');
        $('body').toggleClass('no-scroll');
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