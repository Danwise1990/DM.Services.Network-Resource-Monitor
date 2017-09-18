//<-- Javascript Counter Class, takes a number of arguments to configure number of seconds in the count down and event callback functions -->
function Counter(options) {
    var timer;
    var instance = this;
    var seconds = options.seconds || 10;
    var onUpdateStatus = options.onUpdateStatus || function () { };
    var onCounterEnd = options.onCounterEnd || function () { };
    var onCounterStart = options.onCounterStart || function () { };

    function decrementCounter() {
        onUpdateStatus(seconds);
        if (seconds === 0) {
            stopCounter();
            onCounterEnd();
            return;
        }
        seconds--;
    };

    function startCounter() {
        onCounterStart();
        clearInterval(timer);
        timer = 0;
        decrementCounter();
        timer = setInterval(decrementCounter, 1000);
    };

    function stopCounter() {
        clearInterval(timer);
    };

    function resetCounter() {
        seconds = options.seconds;
    };

    return {
        start: function () {
            startCounter();
        },
        stop: function () {
            stopCounter();
        },
        reset: function () {
            resetCounter();
        }
    }
};