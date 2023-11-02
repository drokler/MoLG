/* tslint:disable */
/* eslint-disable */
/**
 * MotherOfLearningGameWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import type {
  AuthDto,
  AuthResult,
} from '../models/index';
import {
    AuthDtoFromJSON,
    AuthDtoToJSON,
    AuthResultFromJSON,
    AuthResultToJSON,
} from '../models/index';

export interface ApiAuthPostRequest {
    authDto?: AuthDto;
}

export interface ApiAuthPutRequest {
    authDto?: AuthDto;
}

export interface ApiAuthSetupAdminPostRequest {
    authDto?: AuthDto;
}

/**
 * 
 */
export class AuthApi extends runtime.BaseAPI {

    /**
     */
    async apiAuthPostRaw(requestParameters: ApiAuthPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<AuthResult>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.accessToken) {
            const token = this.configuration.accessToken;
            const tokenString = await token("Bearer", []);

            if (tokenString) {
                headerParameters["Authorization"] = `Bearer ${tokenString}`;
            }
        }
        const response = await this.request({
            path: `/api/Auth`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: AuthDtoToJSON(requestParameters.authDto),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => AuthResultFromJSON(jsonValue));
    }

    /**
     */
    async apiAuthPost(requestParameters: ApiAuthPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<AuthResult> {
        const response = await this.apiAuthPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAuthPutRaw(requestParameters: ApiAuthPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<AuthResult>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.accessToken) {
            const token = this.configuration.accessToken;
            const tokenString = await token("Bearer", []);

            if (tokenString) {
                headerParameters["Authorization"] = `Bearer ${tokenString}`;
            }
        }
        const response = await this.request({
            path: `/api/Auth`,
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: AuthDtoToJSON(requestParameters.authDto),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => AuthResultFromJSON(jsonValue));
    }

    /**
     */
    async apiAuthPut(requestParameters: ApiAuthPutRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<AuthResult> {
        const response = await this.apiAuthPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAuthSetupAdminPostRaw(requestParameters: ApiAuthSetupAdminPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<AuthResult>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.accessToken) {
            const token = this.configuration.accessToken;
            const tokenString = await token("Bearer", []);

            if (tokenString) {
                headerParameters["Authorization"] = `Bearer ${tokenString}`;
            }
        }
        const response = await this.request({
            path: `/api/Auth/setup-admin`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: AuthDtoToJSON(requestParameters.authDto),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => AuthResultFromJSON(jsonValue));
    }

    /**
     */
    async apiAuthSetupAdminPost(requestParameters: ApiAuthSetupAdminPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<AuthResult> {
        const response = await this.apiAuthSetupAdminPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}