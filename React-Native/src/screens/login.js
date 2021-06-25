import React, { Component } from 'react';
import { Image, ImageBackground, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        }
    }

    realizarLogin = async () => {
        try {

            const resposta = await api.post('/Login', {
                email: this.state.email,
                senha: this.state.senha,
            });

            const token = resposta.data.token;


            await AsyncStorage.setItem('userToken', token);

            this.props.navigation.navigate('Main');

        } catch (error) {
            console.warn(error)
        }
    };

    render() {
        return (
            <ImageBackground

                style={StyleSheet.absoluteFillObject}
            >
                <View style={styles.overlay} />
                <View style={styles.main}>
                    <View style={styles.form}>
                        <Text style={styles.texto}>Login</Text>
                        <TextInput
                            style={styles.inputLogin}
                            placeholder="Email"
                            placeholderTextColor="#00000080"
                            keyboardType='email-address'
                            onChangeText={email => this.setState({ email })}
                        />

                        <TextInput
                            style={styles.inputLogin}
                            placeholder="Senha"
                            placeholderTextColor="#00000080"
                            secureTextEntry={true}
                            onChangeText={senha => this.setState({ senha })}
                        />

                        <TouchableOpacity
                            style={styles.btnLogin}
                            onPress={this.realizarLogin}
                        >
                            <Text style={styles.btnLoginText}>login</Text>
                        </TouchableOpacity>

                    </View>
                </View>

            </ImageBackground>
        );
    }
};

const styles = StyleSheet.create({

    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: '#8908B7'
    },

    main: {
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center'
    },


    inputLogin: {
        width: 349,
        marginBottom: 30,
        fontSize: 15,
        color: '#464646',
        borderBottomColor: '#903BB9',
        borderBottomWidth: 2
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 43,
        width: 149,
        backgroundColor: '#903BB9',
        borderRadius: 5,
        marginTop: 20
    },

    btnLoginText: {
        fontSize: 20,
        fontFamily: 'Viga',
        color: '#FFF',
        textTransform: 'uppercase'
    },
    form: {
        width: 383,
        height: 325,
        borderRadius: 10,
        backgroundColor: "#FFFFFF",
        shadowColor: "rgba(0, 0, 0, 0.25)",
        shadowOffset: {
            width: 0,
            height: 4
        },
        shadowRadius: 4,
        shadowOpacity: 1,
        alignItems: 'center',
        justifyContent: 'center'
    },
    texto: {
        width: 102,
        height: 46,
        fontFamily: "Chakra Petch",
        fontSize: 35,
        fontWeight: "700",
        fontStyle: "normal",
        lineHeight: 35,
        color: "#464646"
    }

});