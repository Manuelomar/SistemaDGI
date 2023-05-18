import React from "react";
import ReactDOM from "react-dom/client";
import TaxpayerList from "./page/taxpayerList";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { TaxpayerDetail } from "./page/taxpayerDetail";
import './style.scss'
import NavbarComponent from "./components/Header";
const router = createBrowserRouter([
  {
    path: "/",
    element: <TaxpayerList />,
    errorElement: <h1 className="default-message">404 pagina no encontrada</h1>,
  },
  {
    path: "/taxpayer/:id",
    element: <TaxpayerDetail />,
  },
]);

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
        <NavbarComponent/>
    <RouterProvider router={router} />
  </React.StrictMode>
);
