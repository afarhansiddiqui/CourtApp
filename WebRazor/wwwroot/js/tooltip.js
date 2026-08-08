(function () {
    "use strict";
    var GAP = 8; // px space between the trigger/edge and the tooltip

    function position(container) {
        var tip = container.querySelector(".tooltip-content");
        if (!tip) return;

        tip.style.transform = "none";

        var vw = document.documentElement.clientWidth;
        var vh = document.documentElement.clientHeight;
        var trig = container.getBoundingClientRect();
        var box = tip.getBoundingClientRect();

        // Center over the trigger, then clamp inside the viewport
        var left = trig.left + (trig.width / 2) - (box.width / 2);
        left = Math.max(GAP, Math.min(left, vw - box.width - GAP));

        // Prefer above the trigger; fall back to below; clamp to viewport
        var top = trig.top - box.height - GAP;
        if (top < GAP) top = trig.bottom + GAP;
        if (top + box.height > vh - GAP) top = Math.max(GAP, vh - box.height - GAP);

        tip.style.left = Math.round(left) + "px";
        tip.style.top = Math.round(top) + "px";
    }

    function init() {
        document.querySelectorAll(".tooltip-container").forEach(function (c) {
            c.addEventListener("mouseenter", function () { position(c); });
            c.addEventListener("focusin", function () { position(c); });
        });
    }

    if (document.readyState !== "loading") {
        init();
    } else {
        document.addEventListener("DOMContentLoaded", init);
    }
})();