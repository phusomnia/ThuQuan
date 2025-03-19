import React from "react";
import HeaderUser from "./header";
import RenderBody from "./renderBody";
import Footer from "./footer";
import SlideShow from "./slideShow";

export default function UserLayout() {
   return (
      <>
         <HeaderUser />
         <main className="container home">
            <SlideShow />
            <RenderBody />
         </main>
         <Footer />
      </>
   );
}
