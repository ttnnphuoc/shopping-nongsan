const URL = {
    CHECKUSERNAME: "/tai-khoan/IsExistUsername",
    CHECKEMAIL: "/tai-khoan/IsExistEmail",
    GETCATALOGBYID: "/quan-ly/loai-san-pham/GetCatalogById",
    UPDATECATALOG: "/quan-ly/loai-san-pham/UpdateCatalog",
    DELETECATALOG: "/quan-ly/loai-san-pham/DeleteCatalog",
    GETPRODUCTBYID: "/quan-ly/san-pham/GetProductById"
};

const ERROR = {
    EMAIL: "Email đã có người sử dụng.",
    USERNAME: "Tài khoản đã có người sử dụng.",
    PASSWORDNOTMATCH: "Mật khẩu không khớp.",
    EMAIL_FORGOT: "Email chưa được đăng ký.",
    UERNAME_FORGOT: "Tài khoản chưa được đăng ký",
    UPDATE_INFOR_SUCCESS:"Cập nhật thông tin thành công",
    UPDATE_INFOR_FAIL: "Cập nhật thông tin thất bại",
    DELETE_INFOR_SUCCESS:"Xóa thông tin thành công",
    DELETE_INFOR_FAIL: "Xóa thông tin thất bại",
}