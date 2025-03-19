import React, { useEffect, useRef, useState } from "react";
import logoIcon from "@/assets/icons/logo.svg";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { Button, Form, Input, Modal } from "antd";
import { LockKeyhole, UserPen, UserRound } from "lucide-react";
import introRegister from "@/assets/images/auth/intro.png";
import introArrowIcon from "@/assets/icons/intro-arrow.svg";
import { initJsToggle } from "@/assets/js/header";

export default function Register() {
   const navigate = useNavigate();
   const [isShowForgotPassword, setIsShowForgotPassword] = useState(false);
   const [formEmail] = Form.useForm(); // Form cho email
   const emailRefForgotPass = useRef(null);
   const [isLoadingForgotPass, setIsLoadingForgotPass] = useState(false);

   // Hàm mở quên mật khẩu
   const handleForgotPassword = () => {
      setIsShowForgotPassword(true);
      formEmail.resetFields();
      setTimeout(() => {
         if (emailRefForgotPass.current) {
            emailRefForgotPass.current.focus();
         }
      }, 100);
   };

   // Hàm đóng quên mật khẩu
   const handleCloseForgotPassword = () => {
      setIsShowForgotPassword(false);
      formEmail.resetFields();
   };

   // Hàm đóng mở chuyển trạng thái transition
   useEffect(() => {
      initJsToggle();
   }, []);

   // Hàm qua trang register
   const goBackRegister = () => {
      navigate("/register");
   };

   return (
      <>
         {/* Giao diện quên mật khẩu */}
         <Modal
            open={isShowForgotPassword}
            onCancel={handleCloseForgotPassword}
            footer={
               <div className="flex justify-end gap-2">
                  <Button onClick={handleCloseForgotPassword}>Đóng</Button>
                  <Button type="primary" loading={isLoadingForgotPass}>
                     Gửi
                  </Button>
               </div>
            }
         >
            <Form
               form={formEmail}
               requiredMark={false}
               layout="vertical"
               autoComplete="off"
            >
               <Form.Item
                  label={<div className="font-bold">Email</div>}
                  name="email"
                  rules={[
                     {
                        required: true,
                        message: "email không được bỏ trống",
                     },
                     {
                        pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                        message: "email không hợp lệ",
                     },
                  ]}
               >
                  <Input
                     placeholder="Nhập Email"
                     autoComplete="email"
                     ref={emailRefForgotPass}
                  />
               </Form.Item>
            </Form>
         </Modal>

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
                  Chào mừng bạn quay lại để đăng nhập. Là khách hàng quay lại,
                  bạn có thể truy cập vào tất cả thông tin đã lưu trước đó.
               </p>
               <button
                  className="auth__intro-next d-none d-md-flex js-toggle"
                  toggle-target="#auth-content-login"
               >
                  <img src={introArrowIcon} alt="" />
               </button>
            </div>

            {/* Auth content */}
            <div id="auth-content-login" className="auth__content-login hide">
               <div className="auth__content-login-inner">
                  {/* Logo */}
                  <NavLink className="logo auth__content-login-logo ">
                     <img src={logoIcon} alt="Thư quán" className="logo__img" />
                     <h1 className="logo__title">Thư quán</h1>
                  </NavLink>
                  <h1 className="auth__heading">Đăng nhập Tài Khoản</h1>
                  <p className="auth__desc">
                     Chào mừng bạn quay lại để đăng nhập. Là khách hàng quay
                     lại, bạn có thể truy cập vào tất cả thông tin đã lưu trước
                     đó.
                  </p>
                  <Form
                     // onFinish={onFinish}
                     // form={form}
                     layout="vertical"
                     name="basic"
                     autoComplete="off"
                     requiredMark={true}
                     className="form auth__form-login"
                  >
                     <Form.Item
                        className="auth__form-login-item"
                        label={
                           <span className="auth__form-login-lable-input">
                              Email
                           </span>
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
                              <UserRound className="auth__form-login-icon icon" />
                           }
                           placeholder="Email"
                           className="auth__content-input"
                           autoComplete="email"
                        />
                     </Form.Item>

                     <Form.Item
                        className="auth__form-login-item"
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
                              <LockKeyhole className="auth__form-login-icon icon" />
                           }
                           placeholder="Mật khẩu"
                           className="auth__content-input"
                        />
                     </Form.Item>

                     <Form.Item>
                        <div className="auth__form-login-act">
                           <Link
                              onClick={handleForgotPassword}
                              className="auth__form-login-act-forgot"
                           >
                              Quên mật khẩu
                           </Link>
                           <div className="auth__form-login-act-remember">
                              <Input
                                 id="auth__form-login-act-remember-input"
                                 className="auth__form-login-act-remember-input"
                                 type="checkbox"
                              />
                              <label
                                 htmlFor="auth__form-login-act-remember-input"
                                 className="auth__form-login-act-remember-label"
                              >
                                 <p className="auth__form-login-act-remember-text">
                                    Nhớ mật khẩu
                                 </p>
                              </label>
                           </div>
                        </div>
                     </Form.Item>

                     <Form.Item label={null}>
                        <Button
                           className="auth__form-btn-login "
                           type="primary"
                           htmlType="submit"
                        >
                           Đăng nhập
                        </Button>
                     </Form.Item>
                     <div className="auth__form-btn-back-rtegister">
                        <Link onClick={goBackRegister}>Đăng kí tài khoản</Link>
                     </div>
                  </Form>
               </div>
            </div>
         </main>
      </>
   );
}
