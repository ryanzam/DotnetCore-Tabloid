import React from "react"

const Notification = ({ msgType, msg, handleClick }) => {
    return <div className={"alert fixed-bottom alert-dismissible alert-" + msgType}>
        <button type="button" className="btn-close" data-bs-dismiss="alert" onClick={handleClick}></button>
        <strong>{msg}</strong>
    </div>
}

export default Notification