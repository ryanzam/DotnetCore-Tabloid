import React, { useEffect, useState } from 'react'
//import Notification from '../Util/Notification'
import { Journal } from 'react-bootstrap-icons'
import useToken from './useToken';
import { useHistory } from "react-router-dom";

const Login = (props) => {
    const { token, setToken } = useToken();
    let history = useHistory();

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState(null)

    //useEffect(() => {
    //    async function getCategories() {
    //        const res = await fetch('auth/login')
    //        const credentials = await res.json()
    //        setCategory(cat)
    //    } getCategories()
    //}, [])

    const handleSubmit = async e => {
        e.preventDefault()

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password })
        }
        
        try {

            const response = await fetch('auth/login', requestOptions)
                .then(data => data.json())
            if (!response.token) setError("Incorrect Email/Password!")
           props.setToken(response)

        } catch (e) {
            setError(e)
            console.error(e)
        }
    }

    const handleEmailChange = event => {
        setEmail(event.target.value)
    }

    const handlesPwdChange = event => {
        setPassword(event.target.value)
    }

    const handleSignout = () => {
        localStorage.clear()
        history.push("/login");
        window.location.reload();
    }

    if (token) {
        return <div className="d-flex justify-content-center mt-5">
            <div>
                <h1 className="display-5 text-white text-center"><Journal /></h1>
                <h1 className="h3 mb-3 fw-normal">Are you sure? You wanna sign out?</h1>
                <button className="w-100 btn btn-lg btn-primary" type="submit" onClick={handleSignout}>Sign out</button>
            </div>
        </div>
    }

    const disabled = (email.length > 0 && password.length > 0) ? "" : "disabled"

    return <div className="d-flex justify-content-center mt-5">
        <form onSubmit={handleSubmit} className="text-center p-3">
            <h1 className="display-5 text-white"><Journal /></h1>
            <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
            {error && <li className="text-danger pb-2">{error}</li>}
            <div className="form-floating">
                <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com" onChange={handleEmailChange} />
            <label for="floatingInput">Email address</label>
            </div>
            <div className="form-floating">
                <input type="password" className="form-control" id="floatingPassword" placeholder="Password" onChange={handlesPwdChange} />
            <label for="floatingPassword">Password</label>
            </div>

            <button className={"w-100 btn btn-lg btn-primary " + disabled} type="submit">Sign in</button>
        </form>
    </div>
}

export default Login