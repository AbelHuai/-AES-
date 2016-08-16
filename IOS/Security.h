//
//  Security.h
//  com.security.des
//
//  Created by commernet on 14-9-26.
//  Copyright (c) 2014年 commernet. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Security : NSObject
+(NSString*)AesEncrypt:(NSString*)str;
+(NSString*)AesDecrypt:(NSString*)str;
@end
