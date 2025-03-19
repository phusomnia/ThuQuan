import { createBrowserRouter, Navigate } from "react-router-dom";
import LazyLoadComponent from "@/components/base/LazyLoadComponent";
import React from "react";
// Cách import thông thường => làm giảm hiệu năng ứng dụng
// import BookManager from "../pages/user/bookManager";
// import DeviceManager from "../pages/user/deviceManager";
// import BookingHistory from "../pages/user/bookingHistory";
// import Contact from "../pages/user/contact";
// import Register from "../pages/auth/register";
// import Login from "../pages/auth/login";
// import UserLayout from "../layouts/users/UserLayout";

// Tải bằng lazy load
// const UserLayout = React.lazy(() => import("../layouts/users/UserLayout"));
const UserLayout = React.lazy(() => import("@/layouts/users/UserLayout"));
const Login = React.lazy(() => import("@/pages/auth/login"));
const Register = React.lazy(() => import("@/pages/auth/register"));
const BookManager = React.lazy(() => import("@/pages/user/bookManager"));
const DeviceManager = React.lazy(() => import("@/pages/user/deviceManager"));
const BookingHistory = React.lazy(() => import("@/pages/user/bookingHistory"));
const Contact = React.lazy(() => import("@/pages/user/contact"));

const routers = createBrowserRouter([
   {
      path: "/",
      element: (
         <LazyLoadComponent>
            <Login />
         </LazyLoadComponent>
      ),
   },
   {
      path: "/login",
      element: (
         <LazyLoadComponent>
            <Login />
         </LazyLoadComponent>
      ),
   },
   {
      path: "/register",
      element: (
         <LazyLoadComponent>
            <Register />
         </LazyLoadComponent>
      ),
   },
   {
      path: "/user",
      element: (
         <LazyLoadComponent>
            <UserLayout />
         </LazyLoadComponent>
      ),
      children: [
         {
            index: true,
            element: (
               <LazyLoadComponent>
                  <BookManager />
               </LazyLoadComponent>
            ),
         },
         {
            path: "device-manager",
            element: (
               <LazyLoadComponent>
                  <DeviceManager />
               </LazyLoadComponent>
            ),
         },
         {
            path: "booking-history",
            element: (
               <LazyLoadComponent>
                  <BookingHistory />
               </LazyLoadComponent>
            ),
         },
         {
            path: "contact",
            element: (
               <LazyLoadComponent>
                  <Contact />
               </LazyLoadComponent>
            ),
         },
      ],
   },
]);
export default routers;
