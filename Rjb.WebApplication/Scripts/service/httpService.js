var ajaxRequest = function (params) {
    params = params || {};
    params.async = params.async != null ? params.async : true;
    return $.Deferred(function (def) {
        $.ajax({
            url: params.url,
            data: params.data,
            cache: params.cache || false,
            type: params.type || "POST",
            async: params.async,
            contentType: params.contentType || $.ajaxSettings.contentType
        })
            .done(function (result) { def.resolve(result); })
            .fail(function (result, status, error) { def.reject(result, status, error); });
    }).promise();
};

$('body').on('click', '.search-robot', function () {
    var data = {
        StartDate: $('#StartDate').val(),
        EndDate: $('#EndDate').val(),
        SpecializationId: $('#SpecializationId').val(),
    };

    var params = { url: '/robots/GetRobotsOnSpecificDate', data: data }
    $.when(infrastructureService.ajaxRequest(params))
        .done(function (result) {
            $('.robots-block-container').removeClass('hide');
            $('.robots-block').html(result);
        })
        .fail(function () {
            alert('Error occure when search robots');
        });
});

$('body').on('click', '.add-lease', function () {
    var selectedRobots = $('.robot-item:checked');
    var robotIds = new Array();

    if (selectedRobots.length <= 0) {
        alert('Please, select at least one robot.');
        return;
    }

    for (var i = 0; i < selectedRobots.length; i++) {
        robotIds.push($(selectedRobots[i]).data('robot-id'));
    }

    var data = {
        RobotIds: robotIds,
        StartDate: $('#StartDate').val(),
        EndDate: $('#EndDate').val()
    };

    var params = { url: '/Leases/AddLease', data: data }
    $.when(infrastructureService.ajaxRequest(params))
        .done(function (result) {
            window.location = '/Leases/MyLeases'
        })
        .fail(function () {
            alert('Error occure when add lease');
        });
});