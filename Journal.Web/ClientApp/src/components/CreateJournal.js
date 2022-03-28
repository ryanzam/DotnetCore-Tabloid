import React, { useEffect, useState } from 'react'
import Notification from '../Util/Notification'

const CreateJournal = () => {

    const [category, setCategory] = useState([])

    const [title, setTitle] = useState('')
    const [subtitle, setSubTitle] = useState('')
    const [description, setDescription] = useState('')
    const [categoryId, setCategoryId] = useState(1)
    const [categoriesPost, setCategoriesPost] = useState([])

    const [show, setShow] = useState(false)
    const [msgType, setMsgType] = useState("")
    const [msg, setMsg] = useState("")

    useEffect(() => {
        async function getCategories() {
            const res = await fetch('categories')
            const cat = await res.json()
            setCategory(cat)
        } getCategories()
    }, [])

    const handleSubmit = async e => {
        e.preventDefault()
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, subtitle, description, categoryId, categoriesPost })
        }
        try {         
            setShow(true)
            setMsgType("success")
            setMsg("Successfully journal created!")
        } catch (e) {
            setShow(true)
            setMsgType("danger")
            setMsg("Error creating journal :"+ e)
        }
    }

    const handleTitleChange = event => {
        setTitle(event.target.value)
    };

    const handlesTitleChange = event => {
        setSubTitle(event.target.value)
    };

    const handleDesChange = event => {
        setDescription(event.target.value)
    };

    const handleCategory = event => {
        const catId = +event.target.value
        setCategoryId(catId)
    };

    const handleClick = () => {
        setShow(false)
    }

    return <>
        <form onSubmit={handleSubmit}>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="title" className="form-label mt-3">Title</label>
                    <input type="text" className="form-control" id="title" aria-describedby="titleHelp" placeholder="Enter Title" onChange={handleTitleChange} />
                    <small id="titleHelp" className="form-text text-muted">Your journal title.</small>
                </div>
                <div className="form-group">
                    <label htmlFor="stitle" className="form-label mt-3">Sub-Title</label>
                    <input type="text" className="form-control" id="title" aria-describedby="stitleHelp" placeholder="Enter sub-title" onChange={handlesTitleChange}/>
                    <small id="stitleHelp" className="form-text text-muted">Your journal title.</small>
                </div>
                <div className="form-group">
                    <label htmlFor="des" className="form-label mt-3">Description</label>
                    <textarea className="form-control" id="des" rows="5" onChange={handleDesChange}></textarea>
                    <small id="desHelp" className="form-text text-muted">Journal details..</small>
                </div>
                <div className="form-group">
                    <label htmlFor="cat" className="form-label mt-3">Select category</label>
                    <select multiple="" className="form-select" id="cat" onChange={handleCategory}>
                        {category?.map(c => {
                            return <option value={c.id}>{c.title}</option>
                        })} 
                    </select>
                </div>
                <div className="form-group">
                    <button type="submit" className="btn btn-primary mt-3">Submit</button>
                </div>
            </fieldset>
        </form>

        {show && <Notification msgType={msgType} msg={msg} handleClick={handleClick} />}
        </>
}

export default CreateJournal