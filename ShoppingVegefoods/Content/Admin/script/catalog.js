function modalUpdate(catalog,checked) {
    var htmlTemplate =
    `<div class="modal-header">
        <h4 class="modal-title">Thay đổi thông tin</h4>

    </div>
    <div class="modal-body">
        <div class='form-group'>
            <label for='name'>ID</label>
            <input type='text' class='form-control' value = '${catalog.ID}' name='id' id='id' readonly>
        </div>
        <div class='form-group'>
            <label for='name'>Tên</label>
            <input type='text' class='form-control' value = '${catalog.NAME}' name='name' id='name' placeholder='Nhập tên loại'>
        </div>
        <div class='form-group'>
            <label for='name'>Tình trạng (${catalog.STATUS_NAME}) : </label>
            <input type='checkbox' ${checked} value = '${catalog.STATUS_NAME}' name='status' id='status'>
        </div>
    </div>
    <div class="modal-footer justify-content-between">
        <button type="button" class="btn btn-default" data-isreload = '0' onClick="reloadPage()">Đóng</button>
        <button type="button" class="btn btn-primary" onClick="UpdateCatalog()">Lưu</button>
    </div>`;

    // <div class='form-group'>
    //     <label for='parent_id'>Loại Cha</label>
    //     <select class='select2bs4 list-box tri-state form-control' name='parent_id' id='parent_id'>
    //             ${parent_id}
    //     </select>
    // </div>
    // <button type="button" class="close" data-dismiss="modal" aria-label="Close">
    //     <span aria-hidden="true">×</span>
    // </button>
    return htmlTemplate;
}

function loadDataCatalogEdit(id) {
    var $modal = $("#modal-default");
    $.ajax({
        url: URL.GETCATALOGBYID,
        type: "post",
        data: { id: id },
        success: function (data) {
            if (data.result) {
                // var htmlOption = data.catalogDataList.map(function (item) {
                //     return "<option value='" + item.ID + "'>" + item.NAME + "</option>";
                // });
                // var html = "<option value=''>------------</option>" + htmlOption.join("");

                var checked = data.catalog.STATUS === 1 ? "checked" : "";
                $modal.find(".modal-content").html(modalUpdate(data.catalog,checked));

                // Initialize Select2 Elements
                $('.select2bs4').select2({
                    theme: 'bootstrap4'
                });

                $modal.modal("show");
            }
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function UpdateCatalog() {
    var $modal = $("#modal-default");

    var id = $modal.find("input[name='id']").val();
    var name = $modal.find("input[name='name']").val();
    var parentId = $modal.find("select.select2bs4").val();
    var status = $("#status").prop("checked") ? 1 : 2;

    var catalog = {
        ID:id,
        NAME: name,
        PARENT_ID:parentId,
        STATUS: status
    }

    $.ajax({
        type:"post",
        url:URL.UPDATECATALOG,
        data: {cat: JSON.stringify(catalog)},
        success: function(data) {
            if (data.result) {
                notifycation("bg-success","Thông báo",ERROR.UPDATE_INFOR_SUCCESS);
                $(".btn-default").data("isreload",1);
            } else {
                notifycation("bg-danger","Thông báo",ERROR.UPDATE_INFOR_FAIL);
            }
        },
        error: function(error) {
            console.log(error);
        }
    });
}
function showModalDelete (id) {
    var htmlButton =`<button type="button" class="btn btn-primary" onClick="deleteCatalog('${id}')">Xóa</button>`
    showDialogConfirmDelete(htmlButton);
}
function deleteCatalog(id) {
    $.ajax({
        type:"post",
        url:URL.DELETECATALOG,
        data: {id: id},
        success: function(data) {
            console.log(data)
            if (data.result) {
                notifycation("bg-success","Thông báo",ERROR.DELETE_INFOR_SUCCESS);
                $(".btn-default").data("isreload",1);
            } else {
                notifycation("bg-danger","Thông báo",ERROR.DELETE_INFOR_FAIL);
            }
        },
        error: function(error) {
            console.log(error);
        }
    });
}

function reloadPage() {
    $("#modal-default").modal("hide");
    if ($(".btn-default").data().isreload === 1) {
        setTimeout(function() {
            location.reload();
        },2000);
    }
}