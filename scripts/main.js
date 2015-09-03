var Camelonta = (function () {

    // Init scripts
    var init = function () {
        Camelonta.Nav.Init();
        Camelonta.Faq.Init();
        Camelonta.Video.Init();
        Camelonta.Slider.Init();

        // Global resize-event. Triggered if the resize-event has been still for 200ms (debounced)
        // L�gg all logik som h�nder vid resize h�r
        $(window).resize(Camelonta.Helper.Debouncer(function () {
            Camelonta.Nav.PlaceSubmenu();
        }));

        // Hack for making CTA's work correctly when created in Tiny
        $('[class^="button"]').click(function (e) {
            var targetNode = e.target.nodeName;
            if (targetNode === 'SPAN') {
                var link = $(this).find('a'),
                    href = link.attr('href'),
                    target = link.attr('target');
                if (link.length && href !== "") {
                    if (target) {
                        window.open(href, target);
                    } else {
                        window.location.href = href;
                    }
                }
            }
        });
    }

    return {
        Init: init
    }
})();

$(function() {
    Camelonta.Init();
})