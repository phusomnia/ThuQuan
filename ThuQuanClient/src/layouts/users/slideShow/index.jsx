import React from "react";
import { NavLink } from "react-router-dom";
import slideItem_1 from "@/assets/images/slideShow/item-1.png";
import sildeItem_1_md from "@/assets/images/slideShow/item-1-md.png";
export default function SlideShow() {
   return (
      <>
         <div className="home__container">
            {" "}
            <div className="slideshow">
               <div className="slideshow__inner">
                  <div className="slideshow__item">
                     <NavLink>
                        <picture>
                           <source
                              media="(max-width: 767.98px)"
                              srcSet={sildeItem_1_md}
                           />
                           <img
                              src={slideItem_1}
                              alt=""
                              className="slideshow__img"
                           />
                        </picture>
                     </NavLink>
                  </div>
               </div>

               <div className="slideshow__page">
                  <span className="slideshow__num">1</span>
                  <span className="slideshow__slider"></span>
                  <span className="slideshow__num">5</span>
               </div>
            </div>
         </div>
      </>
   );
}
