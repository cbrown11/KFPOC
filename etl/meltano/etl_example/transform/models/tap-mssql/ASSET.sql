{{
  config(
    materialized='table'
  )
}}

with base as (
    select *
    from {{ source('raw', 'Assets') }}
)
select *
from base
