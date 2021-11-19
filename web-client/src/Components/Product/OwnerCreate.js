import React, { useEffect, useState, } from 'react';
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";
const OwnerCreate = props => {
   const { formOwner, setFormOwner,  saveOwner, setSaveOwner} = props;

    const [submitted, setSubmitted] = useState(false);
    const [startDate, setStartDate] = useState(new Date());
    const [file, setFile] = useState(new Date());
    
    const handleChange = (event) => {
        setFile(URL.createObjectURL(event.target.files[0]))
        setFormOwner({
            ...formOwner,
            photo : event.target.files[0]
        })

    }

    const handleInputChange = (event) => {
        // console.log(event.target.name)
        // console.log(event.target.value)
        setFormOwner({
            ...formOwner,
            [event.target.name] : event.target.value
        })
    }

    const handleChangeDate = (ev) => {
        setStartDate(ev);
       
          setFormOwner({
              ...formOwner,
              birthday : ev
            });
    }


    return (
        <div className="submit-form">
                <div>
                    <hr />
                    <div className="card card-outline-secondary">
                        <div className="card-header">
                            <h3 className="mb-0">Owner</h3></div>
                        <div className="card-body" >
                            <div className="form-group">
                                <div className="row">
                                <div className="col-12 col-md-3 col-lg-3 col-sm-12" >
                                        <div>
                                        <img style={{width:'100%', minHeight:'150px'}} src={file} />
                                        <input type="file" onChange={handleChange} />
                                        </div>
                                    </div>
                                    <div className="col-lg-8 col-sm-12">
                                        <div className="row">
                                            <div className="col-12">
                                                <label htmlFor="title">Name</label>
                                                <input
                                                    type="text"
                                                    className="form-control"
                                                    id="name"
                                                    required
                                                    value={formOwner.name}
                                                    onChange={handleInputChange}
                                                    name="name"
                                                />
                                            </div>
                                            <div className="col-6">
                                                <label htmlFor="title">Address</label>
                                                <input
                                                    type="text"
                                                    className="form-control"
                                                    id="address"
                                                    required
                                                    value={formOwner.address}
                                                    onChange={handleInputChange}
                                                    name="address"
                                                />
                                            </div>
                                            <div className="col-6">
                                                <label htmlFor="title">Birthday</label>
                                                <DatePicker
                                                    className="form-control"
                                                    id="birthday"
                                                    selected={startDate}
                                                    value={startDate}
                                                    onChange={(date) => handleChangeDate(date)}
                                                    name="birthday"
                                                />
                                            </div>

                                        </div>
                                    </div>
                                   
                                </div>

                            </div>
                        </div>
                        <div className="card-footer">
                        <button onClick={setSaveOwner} className="btn btn-success float-right">
                        Next
                    </button>
                    
                        </div>
                        </div>

                   
                </div>
        </div >
    )
}

export default OwnerCreate