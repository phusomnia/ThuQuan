import React from "react";
import { Link } from "react-router-dom";
import heartIcon from "@/assets/icons/heart.svg";
import heartRedIcon from "@/assets/icons/heart-red.svg";
import starIcon from "@/assets/icons/star.svg";
import bookItem_1 from "@/assets/images/book/item-1.png";
import bookItem_2 from "@/assets/images/book/item-2.png";
import bookItem_3 from "@/assets/images/book/item-3.png";
import bookItem_4 from "@/assets/images/book/item-4.png";

export default function BookManager() {
   return (
      <>
         <div className="row row-cols-4 row-cols-lg-2 row-cols-sm-1 g-3">
            {/* Book card 1 */}
            <div className="col">
               <article className="book-card">
                  <div className="book-card__img-wrap">
                     <Link>
                        <img
                           src={bookItem_1}
                           alt=""
                           className="book-card__thumb"
                        />
                     </Link>
                     <button className="like-btn book-card__like-btn">
                        <img
                           src={heartIcon}
                           alt=""
                           className="like-btn__icon icon"
                        />
                        <img
                           src={heartRedIcon}
                           alt=""
                           className="like-btn__icon--liked"
                        />
                     </button>
                  </div>
                  <h3 className="book-card__title">
                     <Link>
                        Coffee Beans - Espresso Arabica and Robusta Beans
                     </Link>
                  </h3>
                  <p className="book-card__author">Nguyễn Nhật Ánh</p>
                  <div className="book-card__row">
                     <span className="book-card__price">$47.00</span>
                     <img src={starIcon} alt="" className="book-card__star" />
                     <span className="book-card__score">4.3</span>
                  </div>
               </article>
            </div>
            {/* Book card 2 */}
            <div className="col">
               <article className="book-card">
                  <div className="book-card__img-wrap">
                     <Link>
                        <img
                           src={bookItem_2}
                           alt=""
                           className="book-card__thumb"
                        />
                     </Link>
                     <button className="like-btn book-card__like-btn">
                        <img
                           src={heartIcon}
                           alt=""
                           className="like-btn__icon icon"
                        />{" "}
                        <img
                           src={heartRedIcon}
                           alt=""
                           className="like-btn__icon--liked"
                        />
                     </button>
                  </div>
                  <h3 className="book-card__title">
                     <Link>
                        Lavazza Coffee Blends - Try the Italian Espresso
                     </Link>
                  </h3>
                  <p className="book-card__author">Nguyễn Nhật Ánh</p>
                  <div className="book-card__row">
                     <span className="book-card__price">$53.00</span>
                     <img src={starIcon} alt="" className="book-card__star" />
                     <span className="book-card__score">3.4</span>
                  </div>
               </article>
            </div>
            {/* Book card 3 */}
            <div className="col">
               <article className="book-card">
                  <div className="book-card__img-wrap">
                     <Link>
                        <img
                           src={bookItem_3}
                           alt=""
                           className="book-card__thumb"
                        />
                     </Link>
                     <button className="like-btn like-btn--liked book-card__like-btn">
                        <img
                           src={heartIcon}
                           alt=""
                           className="like-btn__icon icon"
                        />{" "}
                        <img
                           src={heartRedIcon}
                           alt=""
                           className="like-btn__icon--liked"
                        />
                     </button>
                  </div>
                  <h3 className="book-card__title">
                     <Link>
                        Lavazza - Caffè Espresso Black Tin - Ground coffee
                     </Link>
                  </h3>
                  <p className="book-card__author">Nguyễn Nhật Ánh</p>
                  <div className="book-card__row">
                     <span className="book-card__price">$99.99</span>
                     <img src={starIcon} alt="" className="book-card__star" />
                     <span className="book-card__score">5.0</span>
                  </div>
               </article>
            </div>
            {/* Book card 4 */}
            <div className="col">
               <article className="book-card">
                  <div className="book-card__img-wrap">
                     <Link>
                        <img
                           src={bookItem_4}
                           alt=""
                           className="book-card__thumb"
                        />
                     </Link>
                     <button className="like-btn book-card__like-btn">
                        <img
                           src={heartIcon}
                           alt=""
                           className="like-btn__icon icon"
                        />{" "}
                        <img
                           src={heartRedIcon}
                           alt=""
                           className="like-btn__icon--liked"
                        />
                     </button>
                  </div>
                  <h3 className="book-card__title">
                     <Link>
                        Qualità Oro Mountain Grown - Espresso Coffee Beans
                     </Link>
                  </h3>
                  <p className="book-card__author">Nguyễn Nhật Ánh</p>
                  <div className="book-card__row">
                     <span className="book-card__price">$38.65</span>
                     <img src={starIcon} alt="" className="book-card__star" />
                     <span className="book-card__score">4.4</span>
                  </div>
               </article>
            </div>
         </div>
      </>
   );
}
