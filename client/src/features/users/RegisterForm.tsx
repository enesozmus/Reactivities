import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Header } from 'semantic-ui-react';
import MyTextInput from '../../app/common/form/MyTextInput';
import { useStore } from '../../app/stores/store';
import * as Yup from 'yup';
import ValidationErrors from '../errors/ValidationErrors';

export default observer(function RegisterForm() {
    const { userStore } = useStore();
    return (
        <Formik
            initialValues={{ displayName: '', username: '', email: '', password: '', error: null }}
            
            onSubmit={(values, { setErrors }) => userStore.register(values).catch(error =>
                setErrors({ error }))}

            validationSchema={Yup.object({
                firstName: Yup.string().required().min(2, 'Ad alanı 2 karakterden az olmamalı!').max(15, 'Ad alanı 15 karakterden fazla olmamalı!'),
                lastName: Yup.string().required().min(2, 'Soyad alanı 2 karakterden az olmamalı!').max(15, 'Soyadı alanı 15 karakterden fazla olmamalı!'),
                userName: Yup.string().required().min(2, 'Kullanıcı adı alanı 2 karakterden az olmamalı!').max(20, 'Kullanıcı adı alanı 20 karakterden fazla olmamalı!'),
                email: Yup.string().required().email().min(8, 'Email alanı 8 karakterden az olmamalı!').max(20, 'Email alanı 15 karakterden fazla olmamalı!'),
                phoneNumber: Yup.string().required().min(13, 'Telefon numarası alanı 13 karakterden az olmamalı!').max(13, 'Telefon numarası alanı 13 karakterden fazla olmamalı!').matches(/(05|5)[0-9][0-9][ ][1-9]([0-9]){2}[ ]([0-9]){4}/, 'Lütfen 05xx xxx xxxx formatını kullanınız.'),
                password: Yup.string().required().min(8, 'Parola alanı 8 karakterden az olmamalı!').max(20, 'Parola alanı 20 karakterden fazla olmamalı!').matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$/, 'Parola bir rakam[0-9], büyük[A-Z] ve küçük karakter[a-z] ve alfanümerik olmayan bir karakter içermelidir.')
            })}
        >
            {({ handleSubmit, isSubmitting, errors, isValid, dirty }) => (
                <Form className='ui form error' onSubmit={handleSubmit} autoComplete='off'>

                    <Header as='h2' content='Sign up to Reactivites' color='teal' textAlign='center' />

                    <MyTextInput name='firstName' placeholder='Adınız' />
                    <MyTextInput name='lastName' placeholder='Soyadınız' />

                    <MyTextInput name='userName' placeholder='Kullanıcı Adınız' />
                    <MyTextInput name='email' placeholder='Email Adresiniz' />
                    <MyTextInput name='phoneNumber' placeholder='Telefon Numaranız' />
                    <MyTextInput name='password' placeholder='Şifreniz' type='password' />

                    <ErrorMessage
                        name='error' render={() =>
                            <ValidationErrors errors={errors.error} />}
                    />

                    <Button disabled={!isValid || !dirty || isSubmitting}
                        loading={isSubmitting} positive content='Kayıt Ol' type='submit' fluid />
                </Form>
            )}
        </Formik>
    )
})