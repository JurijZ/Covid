import React, { FC } from "react";
import Table from "react-bootstrap/esm/Table";
import { DataResponse, TypedCase } from '../../services/DataService';


interface Props {
    data: TypedCase[];
    renderItem?: (item: TypedCase) => JSX.Element;
}

export const DataList: FC<Props> = ({data, renderItem}) => {

    return (
        <div>
            <Table striped bordered size="sm">
                <thead>
                    <tr>
                        <th>Object Id</th>
                        <th>Confirmation Date</th>
                        <th>Municipality Name</th>
                        <th>Age</th>
                        <th>Gender</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(d => (
                        <tr key={d.object_id}>
                            <td>{d.object_id}</td>
                            <td>{d.confirmation_date}</td>
                            <td>{d.municipality_name}</td>
                            <td>{d.age_bracket}</td>
                            <td>{d.gender}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    )
}