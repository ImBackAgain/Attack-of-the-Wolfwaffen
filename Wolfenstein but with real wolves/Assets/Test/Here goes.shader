// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Shimmmer"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseTex("Noise!", 2D) = "black" {}
	}
	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 100

		GrabPass
		{
			"_WhatsBehind"
		}
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"
		

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 norm : Normal;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 normal : Normal;
				float2 screeenUv : TEXCOORD1;
			};

			sampler2D _MainTex;
			sampler2D _NoiseTex;
			float4 _MainTex_ST;

			float2 FindScreeenUv(float4 position : POSITION)
			{
				float4 clipSpace = UnityObjectToClipPos(position);
				float2 screeenSpace = clipSpace.xy / clipSpace.w;
				screeenSpace.y *= -1;
				screeenSpace = screeenSpace / 2 + 0.5;
				return screeenSpace;
			}

			float Random(float2 from, float min, float max)
			{
				return tex2Dlod(_NoiseTex, float4(from, 0, 0)).r * (max - min) + min;
			}

			float TRandom(float2 from, float min, float max, float2 rate)
			{
				return tex2Dlod(_NoiseTex, float4((from + rate * _Time[1]), 0, 0)).r * (max - min) + min;
			}



			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(
					v.vertex //* TRandom(float2(v.uv), 0.1, 1.5, float2(0, 0.1))
				);

				float4 center = UnityObjectToClipPos(float4(0,0,0,1));
				center.xy /= center.w;

				float4 b = v.vertex;
				b.xy /= b.w;

				float c = length(b.xy-center.xy);


				//o.bluh = 0.5 + 0.5 * o.bluh;
				//o.bluh = 1 + 0.1 / c * sin(c*20);// -_Time[3] * 2);

				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.normal = UnityObjectToWorldNormal(v.norm);

				o.screeenUv = FindScreeenUv(v.vertex * (
					1 + 0.01 / c * sin(c * 20 - _Time[3]*10) //* sin(_Time[3])
					));
				return o;
			}
			
			sampler2D _WhatsBehind;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_WhatsBehind, i.screeenUv);
				//col = i.bluh;
				/*col *= i.normal.y / 2 + 0.8;
				col.a = 0.5;*/
				return col;
			}
			ENDCG
		}
	}
}
