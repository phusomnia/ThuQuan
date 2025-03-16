import { Header } from "../Components/Header";

const Home = () => {
    return(
    <>
        <Header/>
        <a href="/home">Home Page</a><br />
        <a href="/about">About Page</a><br />
        <a href="/contact">Contact Page</a>
    </>
    )
}

export {Home}