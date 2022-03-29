import { useState } from 'react'

export default function useToken() {

    const getToken = () => {
        const tokenStr = localStorage.getItem('token')
        const userToken = JSON.parse(tokenStr)
        return userToken?.token
    }

    const [token, setToken] = useState(getToken())

    const setUserToken = userToken => {
        localStorage.setItem('token', JSON.stringify(userToken))
        setToken(userToken.token)
    }

    return {
        setToken: setUserToken,
        token
    }
}