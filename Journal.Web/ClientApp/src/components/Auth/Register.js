import React, { useEffect, useState } from 'react'
//import Notification from '../Util/Notification'
import { Journal } from 'react-bootstrap-icons'

const Register = (props) => {

    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const handleSubmit = async e => {
        e.preventDefault()

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password })
        }

        try {

            const token = fetch('auth/login', requestOptions)
                .then(data => data.json())

            props.setToken(token)

        } catch (e) {
            console.error(e)
        }
    }
    const handlesUsrChange = event => {
        setUsername(event.target.value)
    }

    const handleEmailChange = event => {
        setEmail(event.target.value)
    }

    const handlesPwdChange = event => {
        setPassword(event.target.value)
    }

    return <div className="d-flex justify-content-center mt-5">
        <form onSubmit={handleSubmit} className="text-center p-3">
            <h1 className="display-5 text-white"><Journal /></h1>
            <h1 className="h3 mb-3 fw-normal">Create new Account!</h1>

            <div className="form-floating">
                <input type="email" className="form-control" id="floatingUsr" placeholder="myusername" onChange={handlesUsrChange} />
                <label for="floatingUsr">Username</label>
            </div>

            <div className="form-floating">
                <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com" onChange={handleEmailChange} />
                <label for="floatingInput">Email address</label>
            </div>
            <div className="form-floating">
                <input type="password" className="form-control" id="floatingPassword" placeholder="Password" onChange={handlesPwdChange} />
                <label for="floatingPassword">Password</label>
            </div>

            <button className="w-100 btn btn-lg btn-primary" type="submit">Register</button>
        </form>
    </div>
}

export default Register