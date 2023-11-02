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

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface CompanyUpdateDto
 */
export interface CompanyUpdateDto {
    /**
     * 
     * @type {string}
     * @memberof CompanyUpdateDto
     */
    id?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CompanyUpdateDto
     */
    name?: string | null;
}

/**
 * Check if a given object implements the CompanyUpdateDto interface.
 */
export function instanceOfCompanyUpdateDto(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function CompanyUpdateDtoFromJSON(json: any): CompanyUpdateDto {
    return CompanyUpdateDtoFromJSONTyped(json, false);
}

export function CompanyUpdateDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): CompanyUpdateDto {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'id': !exists(json, 'id') ? undefined : json['id'],
        'name': !exists(json, 'name') ? undefined : json['name'],
    };
}

export function CompanyUpdateDtoToJSON(value?: CompanyUpdateDto | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'id': value.id,
        'name': value.name,
    };
}
