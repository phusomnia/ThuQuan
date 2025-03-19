import React from "react";
import logoIcon from "@/assets/icons/logo.svg";
import facebookIcon from "@/assets/icons/facebook.svg";
import youtubeIcon from "@/assets/icons/youtube.svg";
import tiktokIcon from "@/assets/icons/tiktok.svg";
import twitterIcon from "@/assets/icons/twitter.svg";
import linkedinIcon from "@/assets/icons/linkedin.svg";
import { Link, NavLink } from "react-router-dom";

export default function Footer() {
   return (
      <>
         <footer className="footer">
            <div className="container">
               <div className="footer__row">
                  {/* Footer column 1 */}
                  <div className="footer__col">
                     {/* Logo */}
                     <NavLink to={"/user"} className="logo footer__logo">
                        <img
                           src={logoIcon}
                           alt="Thư quán"
                           className="logo__img"
                        />
                        <h1 className="logo__title">Thư quán</h1>
                     </NavLink>
                     <p className="footer__desc">
                        Lorem ipsum dolor, sit amet consectetur adipisicing
                        elit. Iste ea corrupti suscipit.
                     </p>

                     <p className="footer__help-text">
                        Receive book or device news and updates.
                     </p>

                     <form action="" className="footer__form">
                        <input
                           className="footer__input"
                           placeholder="Email Address"
                        />
                        <button className="btn btn--primary">Send</button>
                     </form>
                  </div>

                  {/* Footer column 2 */}
                  <div className="footer__col">
                     <h4 className="footer__heading">SHOP</h4>
                     <ul className="footer__list">
                        <li>
                           <a href="#!" className="footer__link">
                              All Departments
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Fashion Deals
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Electronics Discounts
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Home & Living Specials
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Beauty Bargains
                           </a>
                        </li>
                     </ul>
                  </div>

                  {/* Footer column 3 */}
                  <div className="footer__col">
                     <h4 className="footer__heading">SUPPORT</h4>
                     <ul className="footer__list">
                        <li>
                           <a href="#!" className="footer__link">
                              Store locator
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Order status
                           </a>
                        </li>
                     </ul>
                  </div>

                  {/* Footer column 4 */}
                  <div className="footer__col">
                     <h4 className="footer__heading">COMPANY</h4>
                     <ul className="footer__list">
                        <li>
                           <a href="#!" className="footer__link">
                              Customer Service
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Terms of Use
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Privacy
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Careers
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              About
                           </a>
                        </li>
                        <li>
                           <a href="#!" className="footer__link">
                              Affiliates
                           </a>
                        </li>
                     </ul>
                  </div>

                  {/* Footer column 5 */}
                  <div className="footer__col">
                     <h4 className="footer__heading">CONTACT</h4>
                     <ul className="footer__list">
                        <li>
                           <p className="footer__label">Email</p>
                           <a href="#!" className="footer__link">
                              Contact@ThuQuan.com
                           </a>
                        </li>
                        <li>
                           <p className="footer__label">Telephone</p>

                           <a href="#!" className="footer__link">
                              18008888
                           </a>
                        </li>
                        <li>
                           <p className="footer__label">Address</p>

                           <a href="#!" className="footer__text">
                              No. 11D, Lot A10, Nam Trung Yen urban area, Yen
                              Hoa Ward, Cau Giay District, City. Hanoi
                           </a>
                        </li>
                        <li>
                           <p className="footer__label">Hours</p>

                           <a href="#!" className="footer__text">
                              M - F 08:00am - 06:00pm
                           </a>
                        </li>
                     </ul>
                  </div>
               </div>

               {/* footer copyright */}
               <div className="footer__bottom">
                  <p className="footer__copyright">
                     © 2010 - 2025 Thư Quán. Mọi Quyền Được Bảo Lưu.
                  </p>

                  <div className="footer__socials">
                     <Link className="footer__social-link footer__social-link--facebook">
                        <img
                           src={facebookIcon}
                           alt="facebook"
                           className="footer__social-icon icon"
                        />
                     </Link>
                     <Link className="footer__social-link footer__social-link--youtube">
                        <img
                           src={youtubeIcon}
                           alt="youtube"
                           className="footer__social-icon icon"
                        />
                     </Link>
                     <Link className="footer__social-link footer__social-link--tiktok">
                        <img
                           src={tiktokIcon}
                           alt="tiktok"
                           className="footer__social-icon icon"
                        />
                     </Link>
                     <Link className="footer__social-link footer__social-link--twitter">
                        <img
                           src={twitterIcon}
                           alt="twitter"
                           className="footer__social-icon icon"
                        />
                     </Link>
                     <Link className="footer__social-link footer__social-link--linkedin">
                        <img
                           src={linkedinIcon}
                           alt="linkedin"
                           className="footer__social-icon icon"
                        />
                     </Link>
                  </div>
               </div>
            </div>
         </footer>
      </>
   );
}
