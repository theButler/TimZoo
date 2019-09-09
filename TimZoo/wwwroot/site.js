const uri = "api/zoo";

//timer
var hoursLabel;
var minutesLabel;
var totalMinutes;
//setInterval(setTime, 1000);

function setTime() {
    var increment = 10; //jump three minutes at a time to simulate an hour every 20 seconds
    totalMinutes = totalMinutes + increment;
    minutesLabel.innerHTML = pad(totalMinutes % 60);
    if (hoursLabel.innerHTML < pad(parseInt(totalMinutes / 60))) {
        updateAnimals();
    }
    hoursLabel.innerHTML = pad(parseInt(totalMinutes / 60));
}

function pad(val) {
    var valString = val + "";
    if (valString.length < 2) {
        return "0" + valString;
    } else {
        return valString;
    }
}
//timer

$(document).ready(function () {
    getAnimals();
    hoursLabel = document.getElementById("hours");
    minutesLabel = document.getElementById("minutes");
    totalMinutes = 0;
    setInterval(setTime, 1000);
});

function getAnimals() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#animals");

            $(tBody).empty();

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
  
                    .append($("<td></td>").text(item.name))
                    .append($("<td></td>").text(item.health))
                    .append($("<td></td>").text(item.displayStatus));

                tr.appendTo(tBody);
            });

            todos = data;
        }
    });
}

function feedZoo() {
    $.ajax({
        type: "POST",
        url: uri + '/feedzoo',
        cache: false,
        success: function (data) {
            const tBody = $("#animals");

            $(tBody).empty();

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")

                    .append($("<td></td>").text(item.name))
                    .append($("<td></td>").text(item.health))
                    .append($("<td></td>").text(item.displayStatus));

                tr.appendTo(tBody);
            });

            todos = data;
        }
    });
}

function updateAnimals() {
    $.ajax({
        type: "POST",
        url: uri + '/updatezoo',
        cache: false,
        success: function (data) {
            const tBody = $("#animals");

            $(tBody).empty();

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")

                    .append($("<td></td>").text(item.name))
                    .append($("<td></td>").text(item.health))
                    .append($("<td></td>").text(item.displayStatus));

                tr.appendTo(tBody);
            });

            todos = data;
        }
    });
}