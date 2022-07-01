function TaskChosen() {
    $('#choose-and-start-task').removeClass('text-bg-primary');
    $('#choose-and-start-task').addClass('text-bg-light');
    $('#btn-choose-and-start-task').addClass('disabled');

    $('#tool-dispensing-finished').removeClass('text-bg-light');
    $('#tool-dispensing-finished').addClass('text-bg-primary');
    $('#btn-tool-dispensing-finished').removeClass('disabled');
}

function DispensingFinished() {
    $('#tool-dispensing-finished').removeClass('text-bg-primary');
    $('#tool-dispensing-finished').addClass('text-bg-light');
    $('#btn-tool-dispensing-finished').addClass('disabled');
  
    $('#amr-arrived').removeClass('text-bg-light');
    $('#amr-arrived').addClass('text-bg-primary');
    $('#btn-amr-arrived').removeClass('disabled');

}

function AmrArrived() {
    $('#amr-arrived').removeClass('text-bg-primary');
    $('#amr-arrived').addClass('text-bg-light');
    $('#btn-amr-arrived').addClass('disabled');

    $('#tool-withdrawal-finished').removeClass('text-bg-light');
    $('#tool-withdrawal-finished').addClass('text-bg-primary');
    $('#btn-tool-withdrawal-finished').removeClass('disabled');
}

function WithdrawalFinished() {
    $('tool-withdrawal-finished').removeClass('text-bg-primary');
    $('#tool-withdrawal-finished').addClass('text-bg-light');
    $('#btn-tool-withdrawal-finished').addClass('disabled');
    
    $('#choose-and-start-task').removeClass('text-bg-light');
    $('#choose-and-start-task').addClass('text-bg-primary');
    $('#btn-choose-and-start-task').removeClass('disabled');
}

function UpdateCoordinates(x, y, battery) {
    $('#x-coordinate').html(x);
    $('#y-coordinate').html(y);
    $('#battery-status').html(battery);
    //console.log(x + " - " + y + " - " + battery);
}