import React from "react";
import { Link, Outlet } from "react-router-dom";
import categoryItem_1 from "@/assets/images/category/item-1.png";
import categoryItem_2 from "@/assets/images/category/item-2.png";
import categoryItem_3 from "@/assets/images/category/item-3.png";
import filterIcon from "@/assets/icons/filter.svg";

export default function RenderBody() {
   return (
      <>
         <div>
            {/* browse books / devices */}
            <section className="home__container">
               <div className="home__row">
                  <h2 className="home__heading">Duyệt Danh Mục</h2>
               </div>
               <div className="home__cate row row-cols-3 row-cols-md-1">
                  {/* Category Item 1 */}
                  <div className="col">
                     <Link>
                        {" "}
                        <article className="cate-item">
                           <img
                              src={categoryItem_1}
                              alt=""
                              className="cate-item__thumb"
                           />
                           <div class="cate-item__info">
                              <h3 class="cate-item__title">$24 - $150</h3>
                              <p class="cate-item__desc">
                                 New sumatra mandeling coffe blend
                              </p>
                           </div>
                        </article>
                     </Link>
                  </div>
                  {/* Category Item 2 */}
                  <div className="col">
                     <Link>
                        {" "}
                        <article className="cate-item">
                           <img
                              src={categoryItem_2}
                              alt=""
                              className="cate-item__thumb"
                           />
                           <div className="cate-item__info">
                              <h3 className="cate-item__title">$37 - $160</h3>
                              <p className="cate-item__desc">
                                 Espresso arabica and robusta beans
                              </p>
                           </div>
                        </article>
                     </Link>
                  </div>
                  {/* Category Item 3 */}
                  <div className="col">
                     <Link>
                        <article className="cate-item">
                           <img
                              src={categoryItem_3}
                              alt=""
                              className="cate-item__thumb"
                           />
                           <div className="cate-item__info">
                              <h3 className="cate-item__title">$32 - $160</h3>
                              <p className="cate-item__desc">
                                 Lavazza top class whole bean coffee blend
                              </p>
                           </div>
                        </article>
                     </Link>
                  </div>
               </div>
            </section>

            {/* Duyệt sách , thiết bị, lịch sử đặt */}
            <section className="home__container">
               <div className="home__row">
                  <h2 className="home__heading">
                     Chào Mừng{" "}
                     <strong className="home__heading-name">Đức</strong> Đến Thư
                     Quán
                  </h2>
                  <button className="filter-btn">
                     Filter
                     <img
                        src={filterIcon}
                        alt="filter"
                        className="filter-btn__icon icon"
                     />
                  </button>
                  {/* <div className="filter">
                     <h3 className="filter__heading">
                        Filter
                     </h3>
                     <form action="" className="filter__form">
                        <div className="filter__row">
                           <div className="filter__col"></div>
                           <div className="filter__col"></div>
                           <div className="filter__col"></div>
                        </div>
                     </form>
                  </div> */}
               </div>
               <Outlet />
            </section>
         </div>
      </>
   );
}
