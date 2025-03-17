import React, { useEffect } from "react";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { initJsToggle } from "../../../assets/js/header";
import moreIcon from "@/assets/icons/more.svg";
import logoIcon from "@/assets/icons/logo.svg";
import arrowLeftIcon from "@/assets/icons/arrow-left.svg";
import searchIcon from "@/assets/icons/search.svg";
import heartIcon from "@/assets/icons/heart.svg";
import orderIcon from "@/assets/icons/order.svg";
import avatarImage from "@/assets/images/avatar.jpg";
export default function HeaderUser() {
   const navigate = useNavigate();

   useEffect(() => {
      initJsToggle();
   }, []);

   // Chuyển qua trang đăng ký tài khoản
   const handleNextPageResgiter = () => {
      navigate("/register");
   };

   // Chuyển qua trang đăng nhập tài khoản
   const handleNextPageLogin = () => {
      navigate("/login");
   };

   return (
      <>
         <header className="header">
            <div className="container">
               {" "}
               <div className="top_bar">
                  {/* More tablet */}
                  <button
                     className="top_bar__more d-none d-lg-block js-toggle"
                     toggle-target="#navbar"
                  >
                     <img
                        src={moreIcon}
                        alt="more"
                        className="top-bar__more-icon icon"
                     />
                  </button>

                  {/* Logo */}
                  <NavLink to={"/user"} className="logo">
                     <img src={logoIcon} alt="Thư quán" className="logo__img" />
                     <h1 className="logo__title">Thư quán</h1>
                  </NavLink>

                  {/* Navbar */}
                  <nav id="navbar" className="navbar hide">
                     {/* Nut tro ve mobile */}
                     <button
                        className="navbar__close-btn js-toggle"
                        toggle-target="#navbar"
                     >
                        <img src={arrowLeftIcon} alt="back" />
                     </button>

                     {/* action mobile */}
                     <div className="navbar-act">
                        {/* Tim kiem mobile */}
                        <div className="navbar-act__group navbar-act__group--single">
                           <button className="navbar-act__btn">
                              <input
                                 type="text"
                                 name=""
                                 id=""
                                 placeholder="Tìm kiếm ..."
                                 className="navbar-act__search-field"
                              />
                              <div className="navbar-act__separate"></div>
                              <img
                                 src={searchIcon}
                                 alt="Tìm kiếm"
                                 className="navbar-act__icon icon"
                              />
                           </button>
                        </div>

                        {/* Luot thich va lich su dat mobile */}
                        <div className="navbar-act__group">
                           <button className="navbar-act__btn">
                              <img
                                 src={heartIcon}
                                 alt="Tim"
                                 className="navbar-act__icon icon"
                              />
                              <span className="navbar-act__title">03</span>
                           </button>

                           <div className="navbar-act__separate"></div>

                           <button className="navbar-act__btn">
                              <img
                                 src={orderIcon}
                                 alt="Đơn phiếu đặt"
                                 className="navbar-act__icon icon"
                              />
                           </button>
                        </div>
                     </div>

                     <ul className="navbar__list">
                        <li>
                           <NavLink end to="/user" className="navbar__link">
                              Sách
                           </NavLink>
                        </li>
                        <li>
                           <NavLink
                              to="/user/device-manager"
                              className="navbar__link"
                           >
                              Thiết Bị
                           </NavLink>
                        </li>
                        <li>
                           <NavLink
                              to="/user/booking-history"
                              className="navbar__link"
                           >
                              Lịch Sử Đặt
                           </NavLink>
                        </li>
                        <li>
                           <NavLink to="/user/contact" className="navbar__link">
                              Liên Hệ
                           </NavLink>
                        </li>
                     </ul>
                  </nav>

                  {/* Navbar overlay */}
                  <div
                     className="navbar__overlay js-toggle"
                     toggle-target="#navbar"
                  ></div>

                  {/* Actions */}
                  <div className="top-act">
                     <div className="top-act__group d-md-none top-act__group--single">
                        <button className="top-act__btn">
                           <input
                              type="text"
                              name=""
                              id=""
                              placeholder="Tìm kiếm ..."
                              className="top-act__search-field "
                           />
                           <div className="top-act__separate"></div>
                           <img
                              src={searchIcon}
                              alt="Tìm kiếm"
                              className="top-act__icon icon"
                           />
                           <span className="top-act__title"></span>
                        </button>
                     </div>

                     {/* <div className="top-act__group d-md-none">
                        <button className="top-act__btn">
                           <img
                              src={heartIcon}
                              alt="Tim"
                              className="top-act__icon icon"
                           />
                           <span className="top-act__title">03</span>
                        </button>

                        <div className="top-act__separate"></div>

                        <button className="top-act__btn">
                           <img
                              src={orderIcon}
                              alt="Đơn phiếu đặt"
                              className="top-act__icon icon"
                           />
                        </button>
                     </div>

                     <div className="top-act__user">
                        <img
                           src={avatarImage}
                           alt="Ảnh đại diện"
                           className="top-act__avatar"
                        />
                     </div> */}

                     <div className="top-act__group--account">
                        <Link
                           onClick={handleNextPageLogin}
                           className="btn btn--text d-md-none"
                        >
                           Sign In
                        </Link>
                        <Link
                           onClick={handleNextPageResgiter}
                           className="top-act__sign-up btn btn--primary "
                        >
                           Sign Up
                        </Link>
                     </div>
                  </div>
               </div>
            </div>
         </header>
      </>
   );
}
