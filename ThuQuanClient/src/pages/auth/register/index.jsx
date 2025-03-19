import React, { useEffect } from "react";
import logoIcon from "@/assets/icons/logo.svg";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { Button, Form, Input } from "antd";
import { LockKeyhole, UserPen, UserRound } from "lucide-react";
import introRegister from "@/assets/images/auth/intro.png";
import introArrowIcon from "@/assets/icons/intro-arrow.svg";
import { initJsToggle } from "@/assets/js/header";

export default function Register() {
   useEffect(() => {
      initJsToggle();
   }, []);

   const navigate = useNavigate();

   const goBackLogin = () => {
      navigate("/login");
   };

   return (
      <>
         <main className="auth">
            {/* Auth intro */}
            <div className="auth__intro">
               {/* Logo */}
               <NavLink className="logo auth__intro-logo d-none d-md-flex">
                  <img src={logoIcon} alt="Thư quán" className="logo__img" />
                  <h1 className="logo__title">Thư quán</h1>
               </NavLink>
               <img
                  src={introRegister}
                  alt="intro"
                  className="auth__intro-img"
               />

               <p className="auth__intro-text">
                  Những giá trị thương hiệu xa xỉ tốt nhất, sản phẩm chất lượng
                  cao và dịch vụ sáng tạo
               </p>
               <button
                  className="auth__intro-next d-none d-md-flex js-toggle"
                  toggle-target="#auth-content"
               >
                  <img src={introArrowIcon} alt="" />
               </button>
            </div>

            {/* Auth content */}
            <div id="auth-content" className="auth__content hide">
               <div className="auth__content-inner">
                  {/* Logo */}
                  <NavLink className="logo auth__content-logo ">
                     <img src={logoIcon} alt="Thư quán" className="logo__img" />
                     <h1 className="logo__title">Thư quán</h1>
                  </NavLink>
                  <h1 className="auth__heading">Đăng Ký Tài Khoản</h1>
                  <p className="auth__desc">
                     Hãy tạo tài khoản và mua/đặt như một người chuyên nghiệp và
                     tiết kiệm tiền.
                  </p>
                  <Form
                     // onFinish={onFinish}
                     // form={form}
                     layout="vertical"
                     name="basic"
                     autoComplete="off"
                     requiredMark={true}
                     className="form auth__form"
                  >
                     <Form.Item
                        className="auth__form-item"
                        label={
                           <span className="auth__form-lable-input">
                              Tên người dùng
                           </span>
                        }
                        name="username"
                        rules={[
                           {
                              required: true,
                              message: "Tên không được để trống",
                           },
                           {
                              pattern:
                                 /^[a-zA-ZÀÁẠÃẢẶẴẲẮẰÁĂÂẤẪẨẬẦÃÈẼẺẸÉÊẾỀỄỆỂÌÍỈỊIỢỠỚỜỞÕỌỎÒÓỔỖỐỒỘÔÕƯỨỪỰỮỬỤŨỦÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÊƠàáạảãèéẹẻẽìíịỉĩòóọỏõùúụủũơớờợởỡăắằặẳẵâấầậẩẫêếềệểễđĩọỏốồộổỗồờớợởẽẹẻếìíùúụũưữựửữữýỳỵỷỹ ]+$/,
                              message: "Tên chỉ được chứa chữ",
                           },
                        ]}
                     >
                        <Input
                           prefix={<UserPen className="auth__form-icon icon" />}
                           placeholder="Nhập tên"
                           className="auth__content-input"
                        />
                     </Form.Item>
                     <Form.Item
                        className="auth__form-item"
                        label={
                           <span className="auth__form-lable-input">Email</span>
                        }
                        name="email"
                        rules={[
                           {
                              required: true,
                              message: "Email không được để trống",
                           },
                           {
                              pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                              message: "Email không hợp lệ",
                           },
                        ]}
                     >
                        <Input
                           prefix={
                              <UserRound className="auth__form-icon icon" />
                           }
                           placeholder="Email"
                           className="auth__content-input"
                           autoComplete="email"
                        />
                     </Form.Item>

                     <Form.Item
                        className="auth__form-item"
                        label={
                           <span className="auth__form-lable-input">
                              Mật khẩu
                           </span>
                        }
                        name="password"
                        rules={[
                           {
                              required: true,
                              message: "Mật khẩu không được để trống",
                           },
                           {
                              pattern: /^[A-Za-z0-9]{5,}$/,
                              message: "Password phải từ 5 ký tự trở lên",
                           },
                        ]}
                     >
                        <Input.Password
                           prefix={
                              <LockKeyhole className="auth__form-icon icon" />
                           }
                           placeholder="Mật khẩu"
                           className="auth__content-input"
                        />
                     </Form.Item>

                     <Form.Item
                        className="auth__form-item"
                        label={
                           <span className="auth__form-lable-input">
                              Xác nhận mật khẩu
                           </span>
                        }
                        name="Repassword"
                        rules={[
                           {
                              required: true,
                              message: "Mật khẩu không được để trống",
                           },
                           {
                              pattern: /^[A-Za-z0-9]{5,}$/,
                              message: "Password phải từ 5 ký tự trở lên",
                           },
                        ]}
                     >
                        <Input.Password
                           prefix={
                              <LockKeyhole className="auth__form-icon icon" />
                           }
                           placeholder="Mật khẩu"
                           className="auth__content-input"
                        />
                     </Form.Item>

                     <Form.Item label={null}>
                        <Button
                           className="auth__form-btn-register "
                           type="primary"
                           htmlType="submit"
                        >
                           Đăng ký
                        </Button>
                     </Form.Item>
                     <div className="auth__form-btn-back-login">
                        <Link onClick={goBackLogin}>Trở về đăng nhập</Link>
                     </div>
                  </Form>
               </div>
            </div>
         </main>
      </>
   );
}
