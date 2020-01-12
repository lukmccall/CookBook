class Object {
}

class extensions {
}

class RegisterRequest {
    email?: string;
    userName?: string;
    password?: string;

    static fromResponse(data?: any): RegisterRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RegisterRequest();
        
        _response["email"] = _data["email"];
        _response["userName"] = _data["userName"];
        _response["password"] = _data["password"];

        return _response;
    }
}

class AuthSuccessResponse {
    token?: string;
    refreshToken?: string;
    success?: boolean;

    static fromResponse(data?: any): AuthSuccessResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new AuthSuccessResponse();
        
        _response["token"] = _data["token"];
        _response["refreshToken"] = _data["refreshToken"];
        _response["success"] = _data["success"];

        return _response;
    }
}

class LoginRequest {
    email?: string;
    password?: string;

    static fromResponse(data?: any): LoginRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new LoginRequest();
        
        _response["email"] = _data["email"];
        _response["password"] = _data["password"];

        return _response;
    }
}

class LogoutRequest {
    token?: string;

    static fromResponse(data?: any): LogoutRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new LogoutRequest();
        
        _response["token"] = _data["token"];

        return _response;
    }
}

class RefreshRequest {
    token?: string;
    refreshToken?: string;

    static fromResponse(data?: any): RefreshRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RefreshRequest();
        
        _response["token"] = _data["token"];
        _response["refreshToken"] = _data["refreshToken"];

        return _response;
    }
}

class ProblemDetails {
    type: string;
    title: string;
    status: number;
    detail: string;
    instance: string;
    extensions: extensions;

    static fromResponse(data?: any): ProblemDetails {
        const _data = typeof data === 'object' ? data : {};
        const _response = new ProblemDetails();
        
        _response["type"] = _data["type"];
        _response["title"] = _data["title"];
        _response["status"] = _data["status"];
        _response["detail"] = _data["detail"];
        _response["instance"] = _data["instance"];
        _response["extensions"] = _data["extensions"];

        return _response;
    }
}

class MetricResponse {
    unit: string;
    value: number;

    static fromResponse(data?: any): MetricResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new MetricResponse();
        
        _response["unit"] = _data["unit"];
        _response["value"] = _data["value"];

        return _response;
    }
}

class UsResponse {
    unit: string;
    value: number;

    static fromResponse(data?: any): UsResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new UsResponse();
        
        _response["unit"] = _data["unit"];
        _response["value"] = _data["value"];

        return _response;
    }
}

class TemperatureResponse {
    number: number;
    unit: string;

    static fromResponse(data?: any): TemperatureResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new TemperatureResponse();
        
        _response["number"] = _data["number"];
        _response["unit"] = _data["unit"];

        return _response;
    }
}

class PhotoResponse {
    id: number;
    image: string;
    name: string;

    static fromResponse(data?: any): PhotoResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new PhotoResponse();
        
        _response["id"] = _data["id"];
        _response["image"] = _data["image"];
        _response["name"] = _data["name"];

        return _response;
    }
}

class UpdateCurrentUserRequest {
    userName: string;
    userSurname: string;
    age: number;
    description: string;
    phoneNumber: string;

    static fromResponse(data?: any): UpdateCurrentUserRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new UpdateCurrentUserRequest();
        
        _response["userName"] = _data["userName"];
        _response["userSurname"] = _data["userSurname"];
        _response["age"] = _data["age"];
        _response["description"] = _data["description"];
        _response["phoneNumber"] = _data["phoneNumber"];

        return _response;
    }
}

class ChangeCurrentUserPasswordRequest {
    oldPassword?: string;
    newPassword?: string;

    static fromResponse(data?: any): ChangeCurrentUserPasswordRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new ChangeCurrentUserPasswordRequest();
        
        _response["oldPassword"] = _data["oldPassword"];
        _response["newPassword"] = _data["newPassword"];

        return _response;
    }
}

class WidgetResponse {
    code: string;
    defaultCss: boolean;

    static fromResponse(data?: any): WidgetResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new WidgetResponse();
        
        _response["code"] = _data["code"];
        _response["defaultCss"] = _data["defaultCss"];

        return _response;
    }
}

class AmountResponse {
    metric: MetricResponse;
    us: UsResponse;

    static fromResponse(data?: any): AmountResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new AmountResponse();
        
        _response["metric"] = _data["metric"];
        _response["us"] = _data["us"];

        return _response;
    }
}

class EquipmentResponse {
    id: number;
    name: string;
    temperature: TemperatureResponse;

    static fromResponse(data?: any): EquipmentResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new EquipmentResponse();
        
        _response["id"] = _data["id"];
        _response["name"] = _data["name"];
        _response["temperature"] = _data["temperature"];

        return _response;
    }
}

class AuthFailedResponse {
    success?: boolean;
    errors?: Array<string>;

    static fromResponse(data?: any): AuthFailedResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new AuthFailedResponse();
        
        _response["success"] = _data["success"];
        if (Array.isArray(_data["errors"])) {
            _response["errors"] = [] as any;
            for (let _item of _data["errors"]) {
                _response["errors"].push(_item);
            }
        }

        return _response;
    }
}

class FiledErrors {
    field?: string;
    messages?: Array<string>;

    static fromResponse(data?: any): FiledErrors {
        const _data = typeof data === 'object' ? data : {};
        const _response = new FiledErrors();
        
        _response["field"] = _data["field"];
        if (Array.isArray(_data["messages"])) {
            _response["messages"] = [] as any;
            for (let _item of _data["messages"]) {
                _response["messages"].push(_item);
            }
        }

        return _response;
    }
}

class IngredientsResponse {
    image: string;
    name: string;
    amount: AmountResponse;

    static fromResponse(data?: any): IngredientsResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new IngredientsResponse();
        
        _response["image"] = _data["image"];
        _response["name"] = _data["name"];
        _response["amount"] = _data["amount"];

        return _response;
    }
}

class IngredientsRequest {
    ingredients: Array<string>;

    static fromResponse(data?: any): IngredientsRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new IngredientsRequest();
        
        if (Array.isArray(_data["ingredients"])) {
            _response["ingredients"] = [] as any;
            for (let _item of _data["ingredients"]) {
                _response["ingredients"].push(_item);
            }
        }

        return _response;
    }
}

class Ingredient {
    aisle: string;
    amount: number;
    id: number;
    image: string;
    name: string;
    original: string;
    originalName: string;
    originalString: string;
    unit: string;
    unitLong: string;
    unitShort: string;
    metaInformation: Array<string>;

    static fromResponse(data?: any): Ingredient {
        const _data = typeof data === 'object' ? data : {};
        const _response = new Ingredient();
        
        _response["aisle"] = _data["aisle"];
        _response["amount"] = _data["amount"];
        _response["id"] = _data["id"];
        _response["image"] = _data["image"];
        _response["name"] = _data["name"];
        _response["original"] = _data["original"];
        _response["originalName"] = _data["originalName"];
        _response["originalString"] = _data["originalString"];
        _response["unit"] = _data["unit"];
        _response["unitLong"] = _data["unitLong"];
        _response["unitShort"] = _data["unitShort"];
        if (Array.isArray(_data["metaInformation"])) {
            _response["metaInformation"] = [] as any;
            for (let _item of _data["metaInformation"]) {
                _response["metaInformation"].push(_item);
            }
        }

        return _response;
    }
}

class StepInstructionReponse {
    number: number;
    step: string;
    ingredients: Array<PhotoResponse>;
    equipment: Array<EquipmentResponse>;

    static fromResponse(data?: any): StepInstructionReponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new StepInstructionReponse();
        
        _response["number"] = _data["number"];
        _response["step"] = _data["step"];
        if (Array.isArray(_data["ingredients"])) {
            _response["ingredients"] = [] as any;
            for (let _item of _data["ingredients"]) {
                _response["ingredients"].push(_item);
            }
        }
        if (Array.isArray(_data["equipment"])) {
            _response["equipment"] = [] as any;
            for (let _item of _data["equipment"]) {
                _response["equipment"].push(_item);
            }
        }

        return _response;
    }
}

class ValidationFailedResponse {
    status?: boolean;
    errors?: Array<FiledErrors>;

    static fromResponse(data?: any): ValidationFailedResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new ValidationFailedResponse();
        
        _response["status"] = _data["status"];
        if (Array.isArray(_data["errors"])) {
            _response["errors"] = [] as any;
            for (let _item of _data["errors"]) {
                _response["errors"].push(_item);
            }
        }

        return _response;
    }
}

class RecipesPriceBreakdownResponse {
    totalCost: number;
    totalCostPerServing: number;
    ingredients: Array<IngredientsResponse>;

    static fromResponse(data?: any): RecipesPriceBreakdownResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RecipesPriceBreakdownResponse();
        
        _response["totalCost"] = _data["totalCost"];
        _response["totalCostPerServing"] = _data["totalCostPerServing"];
        if (Array.isArray(_data["ingredients"])) {
            _response["ingredients"] = [] as any;
            for (let _item of _data["ingredients"]) {
                _response["ingredients"].push(_item);
            }
        }

        return _response;
    }
}

class RecipeIngredientsResponse {
    ingredients: Array<IngredientsResponse>;

    static fromResponse(data?: any): RecipeIngredientsResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RecipeIngredientsResponse();
        
        if (Array.isArray(_data["ingredients"])) {
            _response["ingredients"] = [] as any;
            for (let _item of _data["ingredients"]) {
                _response["ingredients"].push(_item);
            }
        }

        return _response;
    }
}

class RecipeResponse {
    id: number;
    image: string;
    imageType: string;
    likes: number;
    missedIngredientCount: number;
    title: string;
    usedIngredientCount: number;
    missedIngredients: Array<Ingredient>;
    unusedIngredients: Array<Ingredient>;
    usedIngredients: Array<Ingredient>;

    static fromResponse(data?: any): RecipeResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RecipeResponse();
        
        _response["id"] = _data["id"];
        _response["image"] = _data["image"];
        _response["imageType"] = _data["imageType"];
        _response["likes"] = _data["likes"];
        _response["missedIngredientCount"] = _data["missedIngredientCount"];
        _response["title"] = _data["title"];
        _response["usedIngredientCount"] = _data["usedIngredientCount"];
        if (Array.isArray(_data["missedIngredients"])) {
            _response["missedIngredients"] = [] as any;
            for (let _item of _data["missedIngredients"]) {
                _response["missedIngredients"].push(_item);
            }
        }
        if (Array.isArray(_data["unusedIngredients"])) {
            _response["unusedIngredients"] = [] as any;
            for (let _item of _data["unusedIngredients"]) {
                _response["unusedIngredients"].push(_item);
            }
        }
        if (Array.isArray(_data["usedIngredients"])) {
            _response["usedIngredients"] = [] as any;
            for (let _item of _data["usedIngredients"]) {
                _response["usedIngredients"].push(_item);
            }
        }

        return _response;
    }
}

class RecipeInstructionResponse {
    name: string;
    steps: Array<StepInstructionReponse>;

    static fromResponse(data?: any): RecipeInstructionResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RecipeInstructionResponse();
        
        _response["name"] = _data["name"];
        if (Array.isArray(_data["steps"])) {
            _response["steps"] = [] as any;
            for (let _item of _data["steps"]) {
                _response["steps"].push(_item);
            }
        }

        return _response;
    }
}

export { Object, extensions, RegisterRequest, AuthSuccessResponse, LoginRequest, LogoutRequest, RefreshRequest, ProblemDetails, MetricResponse, UsResponse, TemperatureResponse, PhotoResponse, UpdateCurrentUserRequest, ChangeCurrentUserPasswordRequest, WidgetResponse, AmountResponse, EquipmentResponse, AuthFailedResponse, FiledErrors, IngredientsResponse, IngredientsRequest, Ingredient, StepInstructionReponse, ValidationFailedResponse, RecipesPriceBreakdownResponse, RecipeIngredientsResponse, RecipeResponse, RecipeInstructionResponse };
