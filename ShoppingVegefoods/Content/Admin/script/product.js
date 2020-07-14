function modalUpdate(product,checked, htmlCatalog) {
    var created = toJavaScriptDate(product.CREATED);
    var htmlTemplate =
    `<div class="modal-header">
        <h4 class="modal-title">Thay đổi thông tin</h4>

    </div>
    <form id="data-update">
        <div class="modal-body">
            <div class='form-group'>
                <label for='name'>ID</label>
                <input type='text' class='form-control' value = '${product.ID}' name='id' id='id' readonly>
            </div>
            <div class='form-group'>
                <label for='name'>Tên</label>
                <input type='text' class='form-control' value = '${product.NAME}' name='name' id='name' placeholder='Nhập tên loại'>
            </div>
            <div class='form-group'>
                <label for='catalog_id'>Loại sản phẩm</label>
                <select class='select2bs4 list-box tri-state form-control' name='catalog_id' id='catalog_id'>
                ${htmlCatalog}
                </select>
            </div>
            <div class='form-group'>
                <label for='price'>Giá</label>
                <input type='text' class='form-control' value = '${product.PRICE}' name='price' id='price' placeholder='Nhập giảm giá'>
            </div>

            <div class='form-group'>
                <label for='discount'>Giảm giá</label>
                <input type='text' class='form-control' value = '${product.DISCOUNT}' name='discount' id='discount' placeholder='Nhập giảm giá'>
            </div>
            
            <div class='form-group'>
                <label for='description'>Mô tả</label>
                <textarea id="description" class="form-control" name="description" placeholder="Nhập mô tả" rows="4" cols="50">${product.DESCRIPTION}</textarea>
            </div>

            <div class='form-group'>
                <label for='status'>Tình trạng (${product.STATUS_NAME}) : </label>
                <input type='checkbox' ${checked} value = '${product.STATUS_NAME}' name='status' id='status'>
            </div>

            <div class='form-group'>
                <label for='created'>Ngày tạo</label>
                <input type='text' class='form-control' value = '${created}' name='created' id='created' readonly>
            </div>
            <input type='hidden' class='form-control' value = '${product.IMAGE_LINK}' name='IMAGE_LINK' id='IMAGE_LINK'>
            <div class='form-group'>
                <label for='image'>Hình ảnh</label>
                <img class="img-fluid pad" src="../../Uploads/Products/${product.IMAGE_LINK}" alt=${product.NAME}>
            </div>
            <div class='form-group'>
                <div class="input-group">
                    <div class="custom-file">
                        <input type="file" class="custom-file-input" id="IMAGE_FILE" name="IMAGE_FILE">
                        <label class="custom-file-label" for="IMAGE_FILE">Choose file</label>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div class="modal-footer justify-content-between">
        <button type="button" class="btn btn-default" data-isreload = '0' onClick="reloadPage()">Đóng</button>
        <button type="button" class="btn btn-primary" onClick="updateProduct('${product.ID}')">Lưu</button>
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

function loadDataProductEdit(id) {
    console.log(id);
    var $modal = $("#modal-default");
    $.ajax({
        url: URL.GETPRODUCTBYID,
        type: "post",
        data: { id: id },
        success: function (data) {
            if (data.result) {
                var htmlOption = data.catalogDataList.map(function (item) {
                    return "<option value='" + item.ID + "'>" + item.NAME + "</option>";
                });
                var html = htmlOption.join("");

                var checked = data.product.STATUS === 1 ? "checked" : "";
                $modal.find(".modal-content").html(modalUpdate(data.product,checked,html));

                // Initialize file input
                bsCustomFileInput.init();

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
function updateProduct(id) {
    var name = $("#name").val();
    var catalogId = $("#catalog_id").val();
    var price = $("#price").val();
    var discount = $("#discount").val();
    var description = $("#description").val();
    var status = $("#status").prop("checked") ? 1 : 2;
    var files = $("#IMAGE_FILE").get(0).files;
    var fileName = $("#IMAGE_LINK").val();

    // object data
    var formData = new FormData();
    formData.append("IMAGE_FILE", files[0]);
    formData.append("ID", id);
    formData.append("CATALOG_ID", catalogId);
    formData.append("NAME", name);
    formData.append("PRICE", parseFloat(price));
    formData.append("status", status);
    formData.append("DESCRIPTION", description);
    formData.append("DISCOUNT", discount.trim());
    formData.append("IMAGE_LINK", fileName);

    // Send data
    $.ajax({
        type:"post",
        url:URL.UPDATEPRODUCT,
        data: formData,
        contentType: false,
        processData: false,
        dataType: 'json',
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

function showModalDelete(id) {
    var htmlButton =`<button type="button" class="btn btn-primary" onClick="deleteProduct('${id}')">Xóa</button>`
    showDialogConfirmDelete(htmlButton);
}