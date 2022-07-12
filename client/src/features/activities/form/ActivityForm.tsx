import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { ChangeEvent, useState } from "react";
import { Link, useHistory, useParams } from "react-router-dom";
import { Segment, Header, Form, Button } from "semantic-ui-react"
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useStore } from "../../../app/stores/store";
import { v4 as uuid } from 'uuid';

export default observer(function ActivityForm() {

    // history V5
    const history = useHistory();

    // mobx
    const { activityStore } = useStore();
    const { createActivity, updateActivity, loading, loadActivity, loadingInitial } = activityStore;

    // useParams
    const { id } = useParams<{ id: string }>();

    const [activity, setActivity] = useState({
        id: '',
        title: '',
        date: '',
        description: '',
        category: '',
        city: '',
        venue: ''
        //isCancelled: '',
    });

    // useEffect
    useEffect(() => {
        if (id) loadActivity(id).then(activity => setActivity(activity!))
    }, [id, loadActivity]);


    // Submit
    // Form Açıldığında Yenisini Ekle ya da var olanı Güncelle
    function handleSubmit() {
        if (activity.id.length === 0) {
            let newActivity = {
                ...activity,
                id: uuid()
            }
            createActivity(newActivity).then(() => history.push(`/activities/${newActivity.id}`));
        } else {
            updateActivity(activity).then(() => history.push(`/activities/${activity.id}`));
        }
    }

    // Input Change
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setActivity({ ...activity, [name]: value })
    }

    if (loadingInitial) return <LoadingComponent content="Aktivite yükleniyor..." />

    return (
        <Segment clearing>

            <Header content='Activity Details' sub color='teal' />

            <Form onSubmit={handleSubmit} autoComplete='off'>

                <Form.Input placeholder='Başlık' value={activity.title} name='title' onChange={handleInputChange} />
                <Form.TextArea placeholder='Açıklama' value={activity.description} name='description' onChange={handleInputChange} />
                <Form.Input placeholder='Kategori' value={activity.category} name='category' onChange={handleInputChange} />
                <Form.Input type="date" placeholder='Tarih' value={activity.date} name='date' onChange={handleInputChange} />
                <Form.Input placeholder='Şehir' value={activity.city} name='city' onChange={handleInputChange} />
                <Form.Input placeholder='Mekan' value={activity.venue} name='venue' onChange={handleInputChange} />

                <Button
                    loading={loading}
                    floated='right'
                    positive type="submit"
                    content='Kaydet' />

                <Button
                    as={Link} to='/activities'
                    floated='right'
                    type="button"
                    content='İptal Et' />

            </Form>

        </Segment>
    )
})