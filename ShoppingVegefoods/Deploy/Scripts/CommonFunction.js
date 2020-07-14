function notifycation(cls, title,body, subtitle="") {
    $(document).Toasts('create', {
        class: cls,
        title: title,
        subtitle: subtitle,
        body: body
    });
}

function showDialogConfirmDelete(butonDelete) {
    var htmlTemplate =
    `<div class="modal-header">
        <h4 class="modal-title">Xác nhận</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            
        </button>
    </div>
    <div class="modal-body">
        <div class='form-group'>
            Bạn có chắc chắn muốn xóa không?
        </div>
    </div>
    <div class="modal-footer justify-content-between">
        <button type="button" class="btn btn-default" onClick="reloadPage()">Đóng</button>
        ${butonDelete}
    </div>`;

    var $modal = $("#modal-default");
    $modal.find(".modal-content").html(htmlTemplate);
    $modal.modal("show");
}

function reloadPage() {
    $("#modal-default").modal("hide");
    if ($(".btn-default").data().isreload === 1) {
        setTimeout(function() {
            location.reload();
        },2000);
    }
}

/**
 * @summary
 * @param {*} value 
 * @param {*} isGetTime 
 * @param {*} isFormatMMDDYYYY 
 * @returns
    isGetTime: True is return result with date and time, False is return only date
    isFormatMMDDYYYY: True is format MM/DD/YYYY, False is Format DD/MM/yyyy
 */
function toJavaScriptDate(value, isGetTime = false, isFormatMMDDYYYY = false) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));

    if (isGetTime) {
        return {
            date: dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear(),
            time: dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds()
        }
    }
    
    var date = (dt.getDate()  + "").padStart(2,"0");
    var month = ((dt.getMonth() + 1)+"").padStart(2,"0");

    if (isFormatMMDDYYYY) {
        return month+ "/" + date + "/" + dt.getFullYear();
    } else {
        return date + "/" + month + "/" + dt.getFullYear();
    }
}