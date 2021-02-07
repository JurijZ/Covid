import React, {useState} from "react";
import "./styles.css";
import { useForm } from "react-hook-form";
import { Button } from "react-bootstrap";
import axios, { AxiosResponse } from "axios";

type FormCase = {
    x?: string,
    y?: string,
    case_code?: string,
    confirmation_date: string,
    municipality_code?: string,
    municipality_name?: string,
    age_bracket?: string,
    gender?: string,
    object_id?: string
}

interface TypedCase {
    x?: number,
    y?: number,
    case_code?: string,
    confirmation_date?: Date,
    municipality_code?: string,
    municipality_name?: string,
    age_bracket?: string,
    gender?: string,
    object_id?: number
}


export const NewCasePage = () => {
    const { register, handleSubmit, watch, errors } = useForm<FormCase>();
    const [message, setMessage] = useState('');

    const postData = (data: FormCase) => {

        let typedData : TypedCase = {
            x: Number(data.x),
            y: Number(data.y),
            case_code: data.case_code,
            confirmation_date: new Date(data.confirmation_date),
            municipality_code: data.municipality_code,
            municipality_name: data.municipality_name,
            age_bracket: data.age_bracket,
            gender: data.gender,
        }

        axios({
            method: "post",
            headers: { 'Content-Type': 'application/json' },
            data: typedData,
            url: 'http://localhost:5000/data'
        }).then((resp: AxiosResponse) => {
            console.log(resp.data);
            setMessage(resp.data.id);
        }).catch((err) => {
            console.log(err);
            setMessage('Error')
        });
    }

    //console.log(watch("x"));

    return (
        <form onSubmit={handleSubmit(postData)}>
            <div className="field">
                <label htmlFor="x">Coordinate X</label>
                <input
                    type="text"
                    id="x"
                    name="x"
                    ref={register({ required: true, pattern: /^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$/i })}
                />
                {errors.x && errors.x.type === "required" && (
                    <div className="error">Your must enter coordinate x.</div>
                )}
            </div>
            <div className="field">
                <label htmlFor="y">Coordinate Y</label>
                <input
                    type="text"
                    id="y"
                    name="y"
                    ref={register({ required: true, pattern: /^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$/i })}
                />
                {errors.y && errors.y.type === "required" && (
                    <div className="error">Your must enter coordinate y.</div>
                )}
            </div>
            <div className="field">
                <label htmlFor="confirmation_date">Confirmation Date</label>
                <input
                    type="text"
                    id="confirmation_date"
                    name="confirmation_date"
                    ref={register({ required: true, pattern: /^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$/i })}
                />
                {errors.confirmation_date && errors.confirmation_date.type === "required" && (
                    <div className="error">Your must enter your confirmation_date.</div>
                )}
            </div>

            <Button type="submit">Save</Button>
        </form>
    );
};
