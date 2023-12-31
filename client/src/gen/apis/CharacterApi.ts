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
  CharacterCreateDto,
  CharacterDto,
} from '../models/index';
import {
    CharacterCreateDtoFromJSON,
    CharacterCreateDtoToJSON,
    CharacterDtoFromJSON,
    CharacterDtoToJSON,
} from '../models/index';

export interface CharacterGetByUserUserIdGetRequest {
    userId: string;
}

export interface CharacterPutRequest {
    characterCreateDto?: CharacterCreateDto;
}

/**
 * 
 */
export class CharacterApi extends runtime.BaseAPI {

    /**
     */
    async characterGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<CharacterDto>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.accessToken) {
            const token = this.configuration.accessToken;
            const tokenString = await token("Bearer", []);

            if (tokenString) {
                headerParameters["Authorization"] = `Bearer ${tokenString}`;
            }
        }
        const response = await this.request({
            path: `/Character`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(CharacterDtoFromJSON));
    }

    /**
     */
    async characterGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<CharacterDto>> {
        const response = await this.characterGetRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async characterGetByUserUserIdGetRaw(requestParameters: CharacterGetByUserUserIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<CharacterDto>>> {
        if (requestParameters.userId === null || requestParameters.userId === undefined) {
            throw new runtime.RequiredError('userId','Required parameter requestParameters.userId was null or undefined when calling characterGetByUserUserIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.accessToken) {
            const token = this.configuration.accessToken;
            const tokenString = await token("Bearer", []);

            if (tokenString) {
                headerParameters["Authorization"] = `Bearer ${tokenString}`;
            }
        }
        const response = await this.request({
            path: `/Character/getByUser/{userId}`.replace(`{${"userId"}}`, encodeURIComponent(String(requestParameters.userId))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(CharacterDtoFromJSON));
    }

    /**
     */
    async characterGetByUserUserIdGet(requestParameters: CharacterGetByUserUserIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<CharacterDto>> {
        const response = await this.characterGetByUserUserIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async characterPutRaw(requestParameters: CharacterPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<CharacterDto>> {
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
            path: `/Character`,
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: CharacterCreateDtoToJSON(requestParameters.characterCreateDto),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => CharacterDtoFromJSON(jsonValue));
    }

    /**
     */
    async characterPut(requestParameters: CharacterPutRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<CharacterDto> {
        const response = await this.characterPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
