import React, { useEffect, useState } from 'react';

const CreateJournal = () => {

    const [category, setCategory] = useState([]);

    useEffect(() => {
        async function getCategories() {
            const res = await fetch('categories')
            const cat = await res.json()
            setCategory(cat)
        } getCategories()
    }, [])

    return <>
        <form>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="title" className="form-label mt-3">Title</label>
                    <input type="text" className="form-control" id="title" aria-describedby="titleHelp" placeholder="Enter Title" />
                    <small id="titleHelp" className="form-text text-muted">Your journal title.</small>
                </div>
                <div className="form-group">
                    <label htmlFor="stitle" className="form-label mt-3">Sub-Title</label>
                    <input type="text" className="form-control" id="title" aria-describedby="stitleHelp" placeholder="Enter sub-title" />
                    <small id="stitleHelp" className="form-text text-muted">Your journal title.</small>
                </div>
                <div className="form-group">
                    <label htmlFor="des" className="form-label mt-3">Description</label>
                    <textarea className="form-control" id="des" rows="5"></textarea>
                    <small id="desHelp" className="form-text text-muted">Journal details..</small>
                </div>
                <div className="form-group">
                    <label htmlFor="cat" className="form-label mt-3">Select category</label>
                    <select multiple="" className="form-select" id="cat">
                        {category?.map(c => {
                            return <option>{c.title}</option>
                        })} 
                    </select>
                </div>
                <div className="form-group">
                    <button type="submit" className="btn btn-primary mt-3">Submit</button>
                </div>
            </fieldset>
        </form>
        </>
}

export default CreateJournal